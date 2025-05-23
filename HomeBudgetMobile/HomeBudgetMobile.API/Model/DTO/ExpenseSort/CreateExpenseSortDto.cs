﻿using HomeBudgetMobile.API.Model.DTO.Expense;

namespace HomeBudgetMobile.API.Model.DTO.ExpenseSort
{
    public class CreateExpenseSortDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
