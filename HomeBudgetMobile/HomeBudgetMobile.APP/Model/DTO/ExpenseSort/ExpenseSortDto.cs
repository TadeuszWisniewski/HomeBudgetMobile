using HomeBudgetMobile.APP.Model.DTO.Expense;

namespace HomeBudgetMobile.APP.Model.DTO.ExpenseSort
{
    public class ExpenseSortDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
