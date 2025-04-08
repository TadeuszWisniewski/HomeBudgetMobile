namespace HomeBudgetMobile.APP.Model.Domain
{
    public class Expense
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public char Currency { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid ExpenseSortId { get; set; }


        // Navigation properties
        public ExpenseSort ExpenseSort { get; set; } = null!;
        public List<User> Users { get; } = [];
    }
}
