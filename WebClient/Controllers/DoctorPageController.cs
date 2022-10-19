using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class DoctorPageController : Controller
    {
        public IActionResult Index()
        {
            string active = "active";
            ViewBag.Dashboard = active;
            return View();
        }
    }
}
