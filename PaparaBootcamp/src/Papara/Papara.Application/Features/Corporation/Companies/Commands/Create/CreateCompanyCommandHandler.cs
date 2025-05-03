using Base.Application.Interfaces;
using Base.Domain.Interfaces;
using MediatR;
using Papara.Application.Features.Corporation.Companies.Converters;
using Papara.Application.Features.Corporation.Companies.Models;
using Papara.Domain.Entities.Corporation;

namespace Papara.Application.Features.Corporation.Companies.Commands.Create;


public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserContextService _userContextService;

	public CreateCompanyCommandHandler(IUnitOfWork unitOfWork, IUserContextService userContextService)
	{
		_unitOfWork = unitOfWork;
		_userContextService = userContextService;
	}

	public async Task<CompanyResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
	{
		var dto = request.Request;

		var entity = new Company
		{
			CompanyName = dto.CompanyName,
			TaxNumber = dto.TaxNumber,
			CompanyIBAN = dto.CompanyIBAN,
			CreatedDate = DateTimeOffset.UtcNow,
			CreatedById = _userContextService.GetCurrentUserId() ?? 0,
			IsActive = true
		};

		await _unitOfWork.Repository<Company>().AddAsync(entity);
		await _unitOfWork.CommitAsync();

		return CompanyConverters.CompanyConverter(entity);
	}
}