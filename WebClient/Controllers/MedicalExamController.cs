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
            return View();
        }
    }
}
