namespace HomeBudgetMobile.API.Model.DTO.User
{
    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public List<Income.UpdateIncomeDto> Incomes { get; } = [];
        public List<Saving.UpdateSavingDto> Savings { get; } = [];
        public List<Expense.UpdateExpenseDto> Expenses { get; } = [];
    }
}
