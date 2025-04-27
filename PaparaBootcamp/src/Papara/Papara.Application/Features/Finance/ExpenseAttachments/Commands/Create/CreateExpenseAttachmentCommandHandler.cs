using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseAttachments.Models;
using Papara.Application.Features.Finance.ExpenseAttachments.Converters;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Commands.Create;

public class CreateExpenseAttachmentCommandHandler : IRequestHandler<CreateExpenseAttachmentCommand, ExpenseAttachmentResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IFileService _fileService;
	private readonly IUserContextService _userContextService;

	public CreateExpenseAttachmentCommandHandler(
		IUnitOfWork unitOfWork,
		IFileService fileService,
		IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_fileService = fileService;
		_userContextService = userContextService;
	}

	public async Task<ExpenseAttachmentResponse> Handle(CreateExpenseAttachmentCommand request, CancellationToken cancellationToken)
	{
		using var transaction = _unitOfWork.BeginTransaction();

		try
		{
			var storedFileName = await _fileService.UploadAsync(request.File, "ExpenseAttachments");

			var attachment = new ExpenseAttachment
			{
				ExpenseId = request.ExpenseId,
				OriginalFileName = request.File.FileName,
				StoredFileName = Path.GetFileName(storedFileName),
				ContentType = request.File.ContentType,
				FileSize = request.File.Length,
				FilePath = storedFileName,
				Description = request.Description,
				IsActive = true,
				CreatedById = _userContextService.GetCurrentUserId() ?? 0,
				CreatedDate = DateTimeOffset.UtcNow
			};

			await _unitOfWork.Repository<ExpenseAttachment>().AddAsync(attachment);
			await _unitOfWork.CommitAsync();
			await transaction.CommitAsync();

			return ExpenseAttachmentConverters.ExpenseAttachmentConverter(attachment);
		}
		catch (Exception)
		{
			await transaction.RollbackAsync();
			throw;
		}
	}
}
