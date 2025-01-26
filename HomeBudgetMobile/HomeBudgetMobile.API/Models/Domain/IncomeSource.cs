using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Models.Domain;

[Table("IncomeSource")]
public partial class IncomeSource
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool Active { get; set; }

    [InverseProperty("IdIncomeSourceNavigation")]
    public virtual ICollection<Income> Incomes { get; set; } = new List<Income>();
}
