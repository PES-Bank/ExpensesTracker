using ExpensesTracker.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTracker.Web.Controllers
{
    public class ExpensesController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        private readonly ApplicationDbContext _applicationDbContext;
        public ExpensesController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
