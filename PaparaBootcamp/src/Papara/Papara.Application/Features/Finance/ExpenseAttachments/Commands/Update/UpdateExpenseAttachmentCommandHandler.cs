using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Finance.ExpenseAttachments.Converters;
using Papara.Application.Features.Finance.ExpenseAttachments.Models;
using Papara.Domain.Entities.Finance;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Commands.Update
{
	public class UpdateExpenseAttachmentCommandHandler : IRequestHandler<UpdateExpenseAttachmentCommand, ExpenseAttachmentResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;
		private readonly IUserContextService _userContextService;

		public UpdateExpenseAttachmentCommandHandler(
			IUnitOfWork unitOfWork,
			IFileService fileService,
			IUserContextService userContextService)
		{
			_unitOfWork = unitOfWork;
			_fileService = fileService;
			_userContextService = userContextService;
		}

		public async Task<ExpenseAttachmentResponse> Handle(UpdateExpenseAttachmentCommand request, CancellationToken cancellationToken)
		{
			using var transaction = _unitOfWork.BeginTransaction();

			try
			{
				var entity = await _unitOfWork.Repository<ExpenseAttachment>().GetByIdAsync(request.Id);

				if (entity == null)
					throw new KeyNotFoundException("Dosya kaydı bulunamadı.");

				// Önce eski dosyayı sil
				if (!string.IsNullOrEmpty(entity.FilePath))
				{
					await _fileService.DeleteAsync(entity.FilePath);
				}

				// Yeni dosyayı upload et
				var storedFileName = await _fileService.UploadAsync(request.Request.File, "ExpenseAttachments");

				// Entity güncelle
				entity.OriginalFileName = request.Request.File.FileName;
				entity.StoredFileName = Path.GetFileName(storedFileName);
				entity.ContentType = request.Request.File.ContentType;
				entity.FileSize = request.Request.File.Length;
				entity.FilePath = storedFileName;

				_unitOfWork.Repository<ExpenseAttachment>().Update(entity);
				await _unitOfWork.CommitAsync();
				await transaction.CommitAsync();

				return ExpenseAttachmentConverters.ExpenseAttachmentConverter(entity);
			}
			catch
			{
				await transaction.RollbackAsync();
				throw;
			}
		}
	}
}
