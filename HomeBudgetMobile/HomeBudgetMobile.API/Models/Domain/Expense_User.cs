using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Models.Domain;

[Table("Expense-User")]
public partial class Expense_User
{
    [Key]
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdExpense { get; set; }

    public string? Description { get; set; }

    public bool Active { get; set; }

    [ForeignKey("IdExpense")]
    [InverseProperty("Expense_Users")]
    public virtual Expense IdExpenseNavigation { get; set; } = null!;

    [ForeignKey("IdUser")]
    [InverseProperty("Expense_Users")]
    public virtual User IdUserNavigation { get; set; } = null!;
}
