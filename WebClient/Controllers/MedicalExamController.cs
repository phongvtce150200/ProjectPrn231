using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class MedicalExamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
