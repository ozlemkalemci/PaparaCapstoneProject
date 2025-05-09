﻿using Base.Domain.Entities;
using Papara.Domain.Entities.Finance;
using Papara.Domain.Entities.HR;
using Papara.Domain.Enums.Finance;

public class Expense : BaseEntity
{
	public long EmployeeId { get; set; }
	public Employee Employee { get; set; }

	public decimal Amount { get; set; }
	public string Description { get; set; } = null!;
	public DateTimeOffset ExpenseDate { get; set; }

	public long ExpenseTypeId { get; set; }
	public ExpenseType ExpenseType { get; set; } = null!;

	public bool Concluded { get; set; }

	public string? Location { get; set; }  
	public PaymentMethod PaymentMethod { get; set; }
	public virtual ICollection<ExpenseAttachment> Attachments { get; set; } = new HashSet<ExpenseAttachment>();
	public ICollection<ExpenseApproval>? Approvals { get; set; } 
}
