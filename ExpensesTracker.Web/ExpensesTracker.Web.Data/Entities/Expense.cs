using ExpensesTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Web.Data.Entities
{
    public class Expense : IIdentifiable
    {
        public Guid Id { get; set; }

        public string ExpenseName { get; set; }
        public string ExpenseDescription { get; set;}
        public string ExpenseType { get; set; }
        public string ExpenseAmount { get; set; }

    }
}
