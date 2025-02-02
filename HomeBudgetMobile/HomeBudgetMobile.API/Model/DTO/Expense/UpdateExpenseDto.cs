using HomeBudgetMobile.API.Model.DTO.ExpenseSort;

namespace HomeBudgetMobile.API.Model.DTO.Expense
{
    public class UpdateExpenseDto
    {
        public decimal Amount { get; set; }
        public char Currency { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid ExpenseSortId { get; set; }

        //public ExpenseSortDto ExpenseSort { get; set; } = null!;
    }
}
