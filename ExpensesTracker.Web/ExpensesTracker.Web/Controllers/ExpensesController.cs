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
        public async Task<IActionResult> Add(AddExpenseViewModel viewModel)
        {
            var expense = new Expense
            {
                ExpenseName = viewModel.ExpenseName,
                ExpenseAmount = viewModel.ExpenseAmount,
                ExpenseDescription = viewModel.ExpenseDescription,
                ExpenseType = viewModel.ExpenseType,

            };
            await _applicationDbContext.Expenses.AddAsync(expense);
            await _applicationDbContext.SaveChangesAsync();
            return RedirectToAction("List", "Expenses");
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
            var expense = await _applicationDbContext.Expenses.FindAsync(id);
            return View(expense);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Expense viewModel)
        {
            var expense = await _applicationDbContext.Expenses.FindAsync(viewModel.ExpenseId);
            if (expense is not null)
            {
                expense.ExpenseName = viewModel.ExpenseName;
                expense.ExpenseDescription = viewModel.ExpenseDescription;
                expense.ExpenseAmount = viewModel.ExpenseAmount;
                expense.ExpenseType = viewModel.ExpenseType;

                await _applicationDbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Expenses");
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var expense = await _applicationDbContext.Expenses.FindAsync(id);
            return View(expense);
        }
        [HttpPost]
        public async Task<IActionResult> Details(Expense viewModel)
        {
            var expense = await _applicationDbContext.Expenses.FindAsync(viewModel.ExpenseId);
            
            return RedirectToAction("List", "Expenses");
        }
        [HttpPost]
        public async Task<IActionResult> Remove(Guid id)
        {
            var expense = await _applicationDbContext.Expenses.FindAsync(id);
            if (expense is not null)
            {
                _applicationDbContext.Expenses.Remove(expense);
                await _applicationDbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Expenses");
        }

    }
}
