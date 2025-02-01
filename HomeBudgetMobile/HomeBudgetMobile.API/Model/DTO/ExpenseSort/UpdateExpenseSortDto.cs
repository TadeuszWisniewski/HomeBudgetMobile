namespace HomeBudgetMobile.API.Model.DTO.ExpenseSort
{
    public class UpdateExpenseSortDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
