using Base.Domain.Interfaces;
using MediatR;
using Papara.Domain.Entities.Corporation;

namespace Papara.Application.Features.Corporation.Companies.Commands.Delete;

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Unit>
{
	private readonly IUnitOfWork _unitOfWork;

	public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<Company>().GetByIdAsync(request.Id);

		if (entity == null)
			throw new KeyNotFoundException("Firma bulunamadı.");

		_unitOfWork.Repository<Company>().Delete(entity);
		await _unitOfWork.CommitAsync();

		return Unit.Value;
	}

}
