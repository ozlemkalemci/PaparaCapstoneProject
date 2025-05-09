﻿using MediatR;

namespace Papara.Application.Features.HR.EmployeeAddresses.Commands.Delete;

public class DeleteEmployeeAddressCommand : IRequest<Unit>
{
	public long Id { get; }

	public DeleteEmployeeAddressCommand(long id)
	{
		Id = id;
	}
}