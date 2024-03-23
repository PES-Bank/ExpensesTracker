using ExpensesTracker.Web.Data;
using ExpensesTracker.Web.Data.Entities;
using ExpensesTracker.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTracker.Web.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ExpensesController(ApplicationDbContext dbContext) 
        { 
            this.dbContext=dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddExpenseViewModel viewModel )
        {
            var expense = new Expense
            {
                ExpenseName = viewModel.ExpenseName,
                ExpenseDescription = viewModel.ExpenseDescription,
                ExpenseType = viewModel.ExpenseType,
                ExpenseAmount = viewModel.ExpenseAmount,
            };
            await dbContext.Expenses.AddAsync(expense);
            await dbContext.SaveChangesAsync();
            return View();
        }
       
    }
}
