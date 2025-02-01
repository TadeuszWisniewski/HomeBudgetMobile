namespace HomeBudgetMobile.API.Model.DTO.Goal
{
    public class CreateGoalDto
    {
        public string Name { get; set; }
        public decimal NeededAmount { get; set; }
        public char Currency { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Description { get; set; }
        public bool IsAcive { get; set; } = true;
    }
}
