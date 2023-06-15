using Microsoft.AspNetCore.Mvc;

namespace W4Assessment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
