using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Models.Domain;

[Table("Users-Savings")]
public partial class Users_Saving
{
    [Key]
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdSavings { get; set; }

    public string? Description { get; set; }

    public bool Active { get; set; }

    [ForeignKey("IdSavings")]
    [InverseProperty("Users_Savings")]
    public virtual Saving IdSavingsNavigation { get; set; } = null!;

    [ForeignKey("IdUser")]
    [InverseProperty("Users_Savings")]
    public virtual User IdUserNavigation { get; set; } = null!;
}
