using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebClient.Hubs;

namespace WebClient.Controllers
{
    public class MedicalExamController : Controller
    {
        IHubContext<SignalRServer> _signalRServer;

        public MedicalExamController(IHubContext<SignalRServer> signalRServer)
        {
            _signalRServer = signalRServer;
        }

        public IActionResult Index()
        {
            string active = "active";
            ViewBag.MedicalExam = active;
            string SessionFullname = HttpContext.Session.GetString("fullname");
            ViewData["fullname"] = SessionFullname;
            string SessionRole = HttpContext.Session.GetString("role");
            ViewData["role"] = SessionRole;
            if (!SessionRole.Equals("Doctor") && SessionFullname == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
