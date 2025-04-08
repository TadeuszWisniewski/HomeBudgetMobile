using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetMobile.APP.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public List<Income> Incomes { get; } = new List<Income>();
        public List<Saving> Savings { get; } = new List<Saving>();
        public List<Expense> Expenses { get; } = new List<Expense>();
    }
}
