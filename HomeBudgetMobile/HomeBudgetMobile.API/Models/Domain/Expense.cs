using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Models.Domain;

[Table("Expense")]
public partial class Expense
{
    [Key]
    public int Id { get; set; }

    public int IdExpenseSort { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public bool Active { get; set; }

    [InverseProperty("IdExpenseNavigation")]
    public virtual ICollection<Expense_User> Expense_Users { get; set; } = new List<Expense_User>();

    [ForeignKey("IdExpenseSort")]
    [InverseProperty("Expenses")]
    public virtual ExpenseSort IdExpenseSortNavigation { get; set; } = null!;
}
