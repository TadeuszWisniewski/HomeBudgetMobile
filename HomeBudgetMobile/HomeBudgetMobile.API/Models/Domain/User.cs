using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Models.Domain;

[Table("User")]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Surname { get; set; } = null!;

    public string? Description { get; set; }

    public bool Active { get; set; }

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<Expense_User> Expense_Users { get; set; } = new List<Expense_User>();

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<User_Income> User_Incomes { get; set; } = new List<User_Income>();

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<Users_Saving> Users_Savings { get; set; } = new List<Users_Saving>();
}
