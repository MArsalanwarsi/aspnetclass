using Microsoft.AspNetCore.Mvc;

namespace Complte_website.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
