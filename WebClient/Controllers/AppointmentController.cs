using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WebClient.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WebClient.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        /*   public IActionResult GetEvents(DateTime start, DateTime end)
           {
               var viewModel = new EventViewModel();
               var events = new List<EventViewModel>();
               start = DateTime.Today.AddDays(-14);
               end = DateTime.Today.AddDays(-11);

               for (var i = 1; i <= 5; i++)
               {
                   events.Add(new EventViewModel()
                   {
                       EventID = i,
                       Subject = "Event " + i,
                       Start = start,
                       End = end,
                       IsFullDay = false
                   });

                   start = start.AddDays(7);
                   end = end.AddDays(7);
               }

               var json = JsonConvert.SerializeObject(events);
               return Ok(json);
           }*/
        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            //creat view model for test FE
            var viewModel = new EventViewModel();
            var events = new List<EventViewModel>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-11);

            for (var i = 1; i <= 5; i++)
            {
                events.Add(new EventViewModel()
                {
                    EventID = i,
                    Subject = "Event " + i,
                    Start = start,
                    End = end,
                    IsFullDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }


            return Json(events.ToArray());
        }
    }
}
