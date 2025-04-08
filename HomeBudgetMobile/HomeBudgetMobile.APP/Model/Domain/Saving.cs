namespace HomeBudgetMobile.APP.Model.Domain
{
    public class Saving
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public char Currency { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid GoalId { get; set; }


        // Navigation property
        public Goal Goal { get; set; } = null!;
        public List<User> Users { get; } = [];
    }
}
