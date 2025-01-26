using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Models.Domain;

[Table("Income")]
public partial class Income
{
    [Key]
    public int Id { get; set; }

    public int IdIncomeSource { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public bool Active { get; set; }

    [ForeignKey("IdIncomeSource")]
    [InverseProperty("Incomes")]
    public virtual IncomeSource IdIncomeSourceNavigation { get; set; } = null!;

    [InverseProperty("IdIncomeNavigation")]
    public virtual ICollection<User_Income> User_Incomes { get; set; } = new List<User_Income>();
}
