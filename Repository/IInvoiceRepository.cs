using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetAllInvoice();
        Invoice GetInvoiceById(int id);
        void CreateInvoice(Invoice i);
        void UpdateInvoice(Invoice i);
        void DeleteInvoice(Invoice i);
        List<Invoice> GetInvoiceByDate(DateTime startDate, DateTime endDate);
    }
}
