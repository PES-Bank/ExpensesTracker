using AutoMapper;
using ExpensesTracker.Core.Services.Expenses;
using ExpensesTracker.Core.Services.Workers;
using ExpensesTracker.Web.ViewModels.Expenses;
using ExpensesTracker.Web.ViewModels.Workers;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.Web.Controllers
{
    public class WorkersController : Controller
    {
        private readonly IWorkerService _workerService;
        private readonly IMapper _mapper;

        public WorkersController(IWorkerService workerService, IMapper mapper)
        {
            _workerService = workerService
                ?? throw new ArgumentNullException(nameof(workerService));
            this._mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var workers = this._workerService.GetAllWorkers();
            var viewModels = this._mapper.Map<IEnumerable<WorkerViewModel>>(workers);
            return this.View(viewModels);
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var worker = this._workerService.GetById(id);
            if (worker is null) return this.NotFound();

            var viewModel = this._mapper.Map<WorkerViewModel>(worker);
            return this.View(viewModel);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._workerService.Delete(id);
            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var worker = this._workerService.GetById(id);
            if (worker is null) return this.NotFound();

            var viewModel = this._mapper.Map<WorkerViewModel>(worker);
            return this.View(viewModel);
        }

    }
}
