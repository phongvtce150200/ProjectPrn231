using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            string active = "active";
            ViewBag.PatientManage = active;
            return View();
        }
    }
}
