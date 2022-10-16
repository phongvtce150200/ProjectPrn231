using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class DoctorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
