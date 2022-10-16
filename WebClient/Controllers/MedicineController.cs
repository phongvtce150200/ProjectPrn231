using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class MedicineController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
