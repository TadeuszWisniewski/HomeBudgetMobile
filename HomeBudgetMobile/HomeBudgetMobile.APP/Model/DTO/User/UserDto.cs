namespace HomeBudgetMobile.APP.Model.DTO.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public List<Income.IncomeDto> Incomes { get; } = [];
        public List<Saving.SavingDto> Savings { get; } = [];
        public List<Expense.ExpenseDto> Expenses { get; } = [];
    }
}
