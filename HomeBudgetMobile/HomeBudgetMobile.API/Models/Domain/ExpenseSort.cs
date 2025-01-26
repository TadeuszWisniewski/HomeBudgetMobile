using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Models.Domain;

[Table("ExpenseSort")]
public partial class ExpenseSort
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool Active { get; set; }

    [InverseProperty("IdExpenseSortNavigation")]
    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
