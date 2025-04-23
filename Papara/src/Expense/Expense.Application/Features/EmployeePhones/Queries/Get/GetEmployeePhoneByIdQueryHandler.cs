using Base.Domain.Interfaces;
using Expense.Application.Features.EmployeePhones.Converters;
using Expense.Application.Features.EmployeePhones.Models;
using Expense.Domain.Entities;
using MediatR;

namespace Expense.Application.Features.EmployeePhones.Queries.Get;

public class GetEmployeePhoneByIdQueryHandler : IRequestHandler<GetEmployeePhoneByIdQuery, EmployeePhoneResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetEmployeePhoneByIdQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<EmployeePhoneResponse> Handle(GetEmployeePhoneByIdQuery request, CancellationToken cancellationToken)
	{
		var EmployeePhone = await _unitOfWork.Repository<EmployeePhone>().GetByIdAsync(request.Id);

		if (EmployeePhone == null)
			throw new KeyNotFoundException("Telefon bulunamadı.");

		return EmployeePhoneConverters.EmployeePhoneConverter(EmployeePhone);
	}
}