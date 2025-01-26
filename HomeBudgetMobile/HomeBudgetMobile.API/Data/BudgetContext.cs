using System;
using System.Collections.Generic;
using HomeBudgetMobile.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Data;

public partial class BudgetContext : DbContext
{
    public BudgetContext()
    {
    }

    public BudgetContext(DbContextOptions<BudgetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpenseSort> ExpenseSorts { get; set; }

    public virtual DbSet<Expense_User> Expense_Users { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<IncomeSource> IncomeSources { get; set; }

    public virtual DbSet<Saving> Savings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<User_Income> User_Incomes { get; set; }

    public virtual DbSet<Users_Saving> Users_Savings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=Budget");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdExpenseSortNavigation).WithMany(p => p.Expenses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expense_ExpenseSort");
        });

        modelBuilder.Entity<ExpenseSort>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Expense_User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdExpenseNavigation).WithMany(p => p.Expense_Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expense-User_Expense");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Expense_Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Expense-User_User");
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdIncomeSourceNavigation).WithMany(p => p.Incomes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Income_IncomeSource");
        });

        modelBuilder.Entity<IncomeSource>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.HasData(
                new IncomeSource { Name = "Salary", Active = true });
        });

        modelBuilder.Entity<Saving>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<User_Income>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdIncomeNavigation).WithMany(p => p.User_Incomes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User-Income_Income");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.User_Incomes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User-Income_User");
        });

        modelBuilder.Entity<Users_Saving>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdSavingsNavigation).WithMany(p => p.Users_Savings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users-Savings_Savings");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Users_Savings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users-Savings_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
