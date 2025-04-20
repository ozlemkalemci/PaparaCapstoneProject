using Base.Persistence.Configurations.Base;
using Expense.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Persistence.Configurations.Expense;

public class EmployeeDepartmentConfiguration : BaseEntityConfiguration<EmployeeDepartment>
{
	public override void Configure(EntityTypeBuilder<EmployeeDepartment> builder)
	{
		builder.ToTable("EmployeeDepartments", "Expense");

		base.Configure(builder);

		builder.Property(d => d.DepartmentName)
			.IsRequired()
			.HasMaxLength(150);
	}
}