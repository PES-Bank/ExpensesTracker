namespace ExpensesTracker.Web.ViewModels.Expenses
{
    public class AddExpenseViewModel
    {
        public Guid Id { get; set; }
        public string ExpenseName { get; set; }
        public string ExpenseDescription { get; set; }
        public string ExpenseType { get; set; }
        public string ExpenseAmount { get; set; }

    }
}
