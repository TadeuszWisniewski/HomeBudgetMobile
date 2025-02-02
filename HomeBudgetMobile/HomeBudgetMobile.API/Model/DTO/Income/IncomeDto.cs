using HomeBudgetMobile.API.Model.DTO.IncomeSource;

namespace HomeBudgetMobile.API.Model.DTO.Income
{
    public class IncomeDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public char Currency { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid IncomeSourceId { get; set; }

        public IncomeSourceDto IncomeSource { get; set; } = null!;
    }
}
