namespace HomeBudgetMobile.API.Model.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;


        // Navigation properties
        public List<Income> Incomes { get; } = [];
        public List<Saving> Savings { get; } = [];
        public List<Expense> Expenses { get; } = [];

    }
}
