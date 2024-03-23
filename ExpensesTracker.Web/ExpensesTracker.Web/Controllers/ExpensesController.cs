using ExpensesTracker.Web.Data;
using ExpensesTracker.Web.Data.Entities;

using ExpensesTracker.Web.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTracker.Web.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ExpensesController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
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
            await _applicationDbContext.Expenses.AddAsync(expense);
            await _applicationDbContext.SaveChangesAsync();
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> List() 
        { 
            var expenses = await _applicationDbContext.Expenses.ToListAsync();
            return View(expenses);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) 
        {
            var expenses = await _applicationDbContext.Expenses.FindAsync(id);
            return View(expenses);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Expense viewModel)
        {
            var expenses = await _applicationDbContext.Expenses.FindAsync(viewModel.ExpenseId);
            if (expenses is not null)
            {
                expenses.ExpenseName = viewModel.ExpenseName;
                expenses.ExpenseDescription = viewModel.ExpenseDescription;
                expenses.ExpenseAmount = viewModel.ExpenseAmount;
                expenses.ExpenseName = viewModel.ExpenseName;

                await _applicationDbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Expenses");
        }
                
        [HttpGet]
        public async Task<IActionResult>Remove(Expense viewModel)
        {
            var expense =  await _applicationDbContext.Expenses.FindAsync(viewModel.ExpenseId);
            if (expense is not null)
            {
                _applicationDbContext.Expenses.Remove(viewModel);
                await _applicationDbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Expense");
        }
    }
}
