using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpensesTracker.Web.Data;
using ExpensesTracker.Web.Data.Entities;
using ExpensesTracker.Core.Services.Expenses;
using AutoMapper;
using ExpensesTracker.Web.ViewModels.Expenses;

namespace ExpensesTracker.Web.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;

        public ExpensesController(IExpenseService expenseService, IMapper mapper)
        {
            _expenseService = expenseService
                ?? throw new ArgumentNullException(nameof(expenseService));
            this._mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Index()
        {
            var expenses = this._expenseService.GetAllExpenses();
            var viewModels = this._mapper.Map<IEnumerable<AddExpenseViewModel>>(expenses);
            return this.View(viewModels);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return this.View();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ExpenseCreateModel InputModel)
        {
            if (!ModelState.IsValid) return this.View(InputModel);
            {
                var expense = this._mapper.Map<Expense>(InputModel);
                this._expenseService.Create(expense);

                return this.RedirectToAction(nameof(Index));
            }

        }

        [HttpGet("delete")]
        public IActionResult Delete(Guid id)
        {

            var expense = this._expenseService.GetById(id);
            if (expense is null) return this.NotFound();

            var viewModel = this._mapper.Map<AddExpenseViewModel>(expense);
            return this.View(viewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._expenseService.Delete(id);


            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet("details")]
        public IActionResult Details(Guid id)
        {
            var expense = this._expenseService.GetOne(id);
            if (expense == null)
            {
                return this.NotFound();
            }
            var viewModel = this._mapper.Map<AddExpenseViewModel>(expense);
            return this.View(viewModel);
        }


        [HttpGet("edit")]
        public IActionResult Edit(Guid id)
        {
            var expense = this._expenseService.GetOneEdit(id);
            if (expense is null) return this.NotFound();

            var viewModel = this._mapper.Map<ExpenseEditModel>(expense);
            return View(viewModel);


        }


        [HttpPost("edit"),ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, AddExpenseViewModel inputModel)
        {
            if (!ModelState.IsValid) return this.View(inputModel);
            if (id != inputModel.Id) return this.NotFound();


            var expense = this._expenseService.GetById(id);
            if (expense is null) return this.NotFound();


            this._mapper.Map(inputModel, expense);
            this._expenseService.Update(expense);

            return this.RedirectToAction(nameof(Index));

        }
    }
}
