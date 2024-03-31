using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Core.Projections.Expenses
{
    public record ExpenseEditProjection
    {
        public required Guid Id { get; init; }
        public required string ExpenseName { get; init; }
        public required string ExpenseDescription { get; init; }
        public required string ExpenseType { get; init; }
        public required string ExpenseAmount { get; init; }
    }
}
