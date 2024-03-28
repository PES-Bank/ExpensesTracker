﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Core.Projections.Expenses
{
    public record ExpenseGeneralInfoProjection
    {
        public required Guid ExpenseId { get; init; }
        public required string ExpenseName { get; init; }
        public required string ExpenseDescription { get; init;}
        public required string ExpenseType { get; init;}
        public required string ExpenseAmount { get; init; }

    }
}
