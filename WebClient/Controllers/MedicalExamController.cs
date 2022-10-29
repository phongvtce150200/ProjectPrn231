using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class MedicalExamController : Controller
    {
        public IActionResult Index()
        {
            string active = "active";
            ViewBag.MedicalExam = active;
            string SessionFullname = HttpContext.Session.GetString("fullname");
            ViewData["fullname"] = SessionFullname;
            string SessionRole = HttpContext.Session.GetString("role");
            ViewData["role"] = SessionRole;
            if(!SessionRole.Equals("Doctor"))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
