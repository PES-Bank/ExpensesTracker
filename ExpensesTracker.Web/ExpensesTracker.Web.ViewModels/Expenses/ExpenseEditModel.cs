using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Web.ViewModels.Expenses
{
	public record  ExpenseEditModel: ExpenseCreateModel
	{
		public required Guid Id { get; init; }
	}
}
