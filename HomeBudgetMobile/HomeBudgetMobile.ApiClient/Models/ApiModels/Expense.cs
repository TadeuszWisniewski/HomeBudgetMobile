using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetMobile.APP.Models
{
    public class Expense
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public char Currency { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid ExpenseSortId { get; set; }

        public ExpenseSort ExpenseSort { get; set; } = null!;
        public List<User> Users { get; } = new List<User>();
    }
}
