using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Corporation.Companies.Converters;
using Papara.Application.Features.Corporation.Companies.Models;
using Papara.Domain.Entities.Corporation;

namespace Papara.Application.Features.Corporation.Companies.Queries.Get;

public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetCompanyByIdQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<CompanyResponse> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
	{
		var company = await _unitOfWork.Repository<Company>().GetByIdAsync(request.Id);

		if (company == null)
			throw new KeyNotFoundException("Firma bulunamadı.");

		return CompanyConverters.CompanyConverter(company);
	}
}
