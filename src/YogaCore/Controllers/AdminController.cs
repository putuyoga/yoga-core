using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace YogaCore.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
