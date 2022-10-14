using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public void CreateInvoice(Invoice i) => InvoiceDAO.CreateInvoice(i);

        public void DeleteInvoice(Invoice i) => InvoiceDAO.DeleteInvoice(i);

        public List<Invoice> GetAllInvoice() => InvoiceDAO.GetInvoice();

        public List<Invoice> GetInvoiceByDate(DateTime startDate, DateTime endDate) => InvoiceDAO.GetByDate(startDate,endDate);

        public Invoice GetInvoiceById(int id) => InvoiceDAO.FindInvoiceById(id);

        public void UpdateInvoice(Invoice i) => InvoiceDAO.UpdateInvoice(i);
    }
}
