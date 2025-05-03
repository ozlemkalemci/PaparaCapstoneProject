using Base.Application.Common.Extensions;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Corporation.Companies.Converters;
using Papara.Application.Features.Corporation.Companies.Models;
using Papara.Domain.Entities.Corporation;
using System.Linq.Expressions;

namespace Papara.Application.Features.Corporation.Companies.Queries.GetAll;

public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyResponse>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetAllCompaniesQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<List<CompanyResponse>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
	{
		var filter = (Expression<Func<Company, bool>>)(x => x.IsActive);
		var includes = new List<Expression<Func<Company, object>>>();

		var companies = await _unitOfWork.Repository<Company>().GetAllAsync(filter, includes.ToArray());
		return CompanyConverters.CompanyConverterList(companies);
	}
}
