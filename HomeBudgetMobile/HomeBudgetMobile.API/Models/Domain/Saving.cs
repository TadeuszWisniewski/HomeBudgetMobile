using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Models.Domain;

public partial class Saving
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string GoalName { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public bool Active { get; set; }

    [InverseProperty("IdSavingsNavigation")]
    public virtual ICollection<Users_Saving> Users_Savings { get; set; } = new List<Users_Saving>();
}
