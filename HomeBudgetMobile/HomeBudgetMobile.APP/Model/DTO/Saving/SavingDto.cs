namespace HomeBudgetMobile.APP.Model.DTO.Saving
{
    public class SavingDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public char Currency { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid GoalId { get; set; }
    }
}
