using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class ReceivePatientController : Controller
    {
        public IActionResult Index()
        {
            string active = "active";
            ViewBag.ReceivePatient = active;
            return View();
        }
    }
}
