﻿namespace HomeBudgetMobile.APP.Model.Domain
{
    public class Goal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal NeededAmount { get; set; }
        public char Currency { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Description { get; set; }
        public bool IsAcive { get; set; } = true;


        // Navigation properties
        public ICollection<Saving> Saving { get; } = new List<Saving>();
    }
}
