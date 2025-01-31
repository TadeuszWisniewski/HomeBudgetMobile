namespace HomeBudgetMobile.API.Model.Domain
{
    public class Income
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public char Currency { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid IncomeSourceId { get; set; }


        // Navigation properties
        public IncomeSource IncomeSource { get; set; } = null!;
        public List<User> Users { get; } = [];
    }
}
