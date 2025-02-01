namespace HomeBudgetMobile.API.Model.DTO.Income
{
    public class UpdateIncomeDto
    {
        public decimal Amount { get; set; }
        public char Currency { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid IncomeSourceId { get; set; }
    }
}
