using Microsoft.AspNetCore.Mvc;

namespace taskManagerWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
