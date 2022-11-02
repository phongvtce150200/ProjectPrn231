using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string SessionFullname = HttpContext.Session.GetString("fullname");
            ViewData["fullname"] = SessionFullname;
            string SessionRole = HttpContext.Session.GetString("role");
            ViewData["role"] = SessionRole;

            if (SessionFullname == null && SessionRole == null)
            {
                return View();
            }
            if (SessionRole.Equals("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            if (SessionRole.Equals("Nurse"))
            {
                return RedirectToAction("Index", "ReceivePatient");
            }
            if (SessionRole.Equals("Doctor"))
            {
                return RedirectToAction("Index", "MedicalExam");
            }
            return View();
        }
    }
}
