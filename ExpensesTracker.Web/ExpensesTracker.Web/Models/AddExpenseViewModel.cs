namespace ExpensesTracker.Web.Models
{
    public class AddExpenseViewModel
    {
        public string ExpenseName { get; set;}
        public string ExpenseDescription { get; set; }
        public string ExpenseType { get; set; }
        public double  ExpenseAmount { get; set; }

    }
}
