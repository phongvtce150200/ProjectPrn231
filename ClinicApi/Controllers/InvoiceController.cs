using BusinessObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceController : ControllerBase
    {
        private IInvoiceRepository _invoiceRepository = new InvoiceRepository();

        // GET: api/<InvoiceController>
        [HttpGet]
        public ActionResult<IEnumerable<Invoice>> GetInvoice()
        {
            var i = _invoiceRepository.GetAllInvoice();
            if (i == null)
            {
                return NoContent();
            }
            /* JsonSerializerSettings jss = new JsonSerializerSettings();
             jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
             string jsons = JsonConvert.SerializeObject(i, jss);
             return Content(jsons, "application/json");*/
            return Ok(i);
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public IActionResult GetInvoiceById(int id)
        {
            var i = _invoiceRepository.GetInvoiceById(id);
            if(i == null)
            {
                return NotFound();
            }
            return Ok(i);
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public IActionResult CreateInvoice(Invoice invoice)
        {
             _invoiceRepository.CreateInvoice(invoice);
            return Ok(invoice);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateInvoice(int id, Invoice invoice)
        {
            var iTmp = _invoiceRepository.GetInvoiceById(id);
            if (iTmp == null)
            {
                return NotFound();
            }
            _invoiceRepository.UpdateInvoice(invoice);
            return Ok(invoice);
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            var iTmp = _invoiceRepository.GetInvoiceById(id);
            if (iTmp == null)
            {
                return NotFound();
            }
            _invoiceRepository.DeleteInvoice(iTmp);
            return Ok(iTmp);
        }
    }
}
