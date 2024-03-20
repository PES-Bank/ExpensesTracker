using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.Web.Controllers
{
    public class ExpensesController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
