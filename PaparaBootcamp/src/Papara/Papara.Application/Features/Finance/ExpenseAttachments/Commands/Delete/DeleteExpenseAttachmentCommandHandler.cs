using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;

namespace Papara.Application.Features.Finance.ExpenseAttachments.Commands.Delete
{
	public class DeleteExpenseAttachmentCommandHandler : IRequestHandler<DeleteExpenseAttachmentCommand, Unit>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;

		public DeleteExpenseAttachmentCommandHandler(IUnitOfWork unitOfWork, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_fileService = fileService;
		}

		public async Task<Unit> Handle(DeleteExpenseAttachmentCommand request, CancellationToken cancellationToken)
		{
			using var transaction = _unitOfWork.BeginTransaction();

			try
			{
				var entity = await _unitOfWork.Repository<ExpenseAttachment>().GetByIdAsync(request.Id);

				if (entity == null)
					throw new KeyNotFoundException("Dosya bulunamadı.");

				// Dosyayı fiziksel ortamdan sil
				if (!string.IsNullOrEmpty(entity.FilePath))
				{
					await _fileService.DeleteAsync(entity.FilePath);
				}

				// Veritabanı kaydını soft delete yap
				_unitOfWork.Repository<ExpenseAttachment>().Delete(entity);

				await _unitOfWork.CommitAsync();
				await transaction.CommitAsync(); 

				return Unit.Value;
			}
			catch
			{
				await transaction.RollbackAsync();
				throw;
			}
		}
	}
}
