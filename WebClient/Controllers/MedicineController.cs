using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Medicine = WebClient.Models.Medicine;

namespace WebClient.Controllers
{
    public class MedicineController : Controller
    {
        HttpClient client = new HttpClient();
        public async Task<IActionResult> Index()
        {
            string active = "active";
            ViewBag.MedicineManage = active;

            HttpClient client = new HttpClient();
            HttpResponseMessage respone = await client.GetAsync("https://localhost:5001/api/Medicine");
            string data = await respone.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            List<Medicine> list = JsonSerializer.Deserialize<List<Medicine>>(data, options);
            return View(list);
         
        }
        public async Task<IActionResult> Find(int id)
        {
            HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/Medicine/" + id);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                Medicine medicine = JsonSerializer.Deserialize<Medicine>(data);
                //var date = medicine.expiration.Date;

                /* var myMedicine = new
                {
                    medicineId = medicine.medicineId,
                    medicineName = medicine.medicineName,
                    price = medicine.medicineId,
                    expiration = medicine.expiration.ToShortDateString(),
                    amount = medicine.amount
                };
                var test = myMedicine;*/


                return new JsonResult(medicine);

            }
            return RedirectToAction("Index", "Medicine");


        }
    }
}
