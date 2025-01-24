using Microsoft.AspNetCore.Mvc;

namespace Backend3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}