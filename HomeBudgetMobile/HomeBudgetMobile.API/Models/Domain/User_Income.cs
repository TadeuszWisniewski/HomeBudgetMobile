using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Models.Domain;

[Table("User-Income")]
public partial class User_Income
{
    [Key]
    public int Id { get; set; }

    public int IdIncome { get; set; }

    public int IdUser { get; set; }

    public string? Description { get; set; }

    public bool Active { get; set; }

    [ForeignKey("IdIncome")]
    [InverseProperty("User_Incomes")]
    public virtual Income IdIncomeNavigation { get; set; } = null!;

    [ForeignKey("IdUser")]
    [InverseProperty("User_Incomes")]
    public virtual User IdUserNavigation { get; set; } = null!;
}
