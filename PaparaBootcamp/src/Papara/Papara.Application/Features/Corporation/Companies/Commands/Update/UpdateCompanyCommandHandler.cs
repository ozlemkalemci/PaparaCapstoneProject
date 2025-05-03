using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Corporation.Companies.Converters;
using Papara.Application.Features.Corporation.Companies.Models;
using Papara.Domain.Entities.Corporation;

namespace Papara.Application.Features.Corporation.Companies.Commands.Update;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, CompanyResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<CompanyResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<Company>().GetByIdAsync(request.Id);
		if (entity == null)
			throw new KeyNotFoundException("Firma bulunamadı.");

		var dto = request.Request;

		entity.CompanyName = dto.CompanyName;
		entity.TaxNumber = dto.TaxNumber;
		entity.CompanyIBAN = dto.CompanyIBAN;

		_unitOfWork.Repository<Company>().Update(entity);
		await _unitOfWork.CommitAsync();

		return CompanyConverters.CompanyConverter(entity);
	}
}