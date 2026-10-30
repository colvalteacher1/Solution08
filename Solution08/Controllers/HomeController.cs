
using Microsoft.AspNetCore.Mvc;

namespace Solution08.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
