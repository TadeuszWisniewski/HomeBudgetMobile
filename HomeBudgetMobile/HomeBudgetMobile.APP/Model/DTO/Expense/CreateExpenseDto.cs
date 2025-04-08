using HomeBudgetMobile.APP.Model.DTO.ExpenseSort;

namespace HomeBudgetMobile.APP.Model.DTO.Expense
{
    public class CreateExpenseDto
    {
        public decimal Amount { get; set; }
        public char Currency { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid ExpenseSortId { get; set; }

        //public ExpenseSortDto ExpenseSort { get; set; } = null!;
    }
}
