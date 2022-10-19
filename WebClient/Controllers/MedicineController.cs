using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class MedicineController : Controller
    {
        public IActionResult Index()
        {
            string active = "active";
            ViewBag.MedicineManage = active;
            return View();
        }
    }
}
