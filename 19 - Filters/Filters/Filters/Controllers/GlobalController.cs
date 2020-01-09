using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    public class GlobalController : Controller
    {
        public IActionResult Index() => View("Message", "This is the global controller");
    }
}
