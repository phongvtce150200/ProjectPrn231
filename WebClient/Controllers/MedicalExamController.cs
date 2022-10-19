using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class MedicalExamController : Controller
    {
        public IActionResult Index()
        {
            string active = "active";
            ViewBag.MedicalExam = active;
            return View();
        }
    }
}
