namespace HomeBudgetMobile.API.Model.Domain
{
    public class IncomeSource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;


        public ICollection<Income> Incomes { get; } = new List<Income>();
    }
}
