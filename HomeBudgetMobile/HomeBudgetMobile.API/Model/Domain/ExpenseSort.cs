namespace HomeBudgetMobile.API.Model.Domain
{
    public class ExpenseSort
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;


        // Navigation properties
        public ICollection<Expense> Expenses { get; } = new List<Expense>();
    }
}
