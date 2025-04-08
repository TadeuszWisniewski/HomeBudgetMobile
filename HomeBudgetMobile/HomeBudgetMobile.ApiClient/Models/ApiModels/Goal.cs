using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetMobile.APP.Models
{
    public class Goal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal NeededAmount { get; set; }
        public char Currency { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string? Description { get; set; }
        public bool IsAcive { get; set; } = true;

        public ICollection<Saving> Saving { get; } = new List<Saving>();
    }
}
