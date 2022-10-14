using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class InvoiceDAO
    {
        public static List<Invoice> GetInvoice()
        {
            var listInvoice = new List<Invoice>();
            
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    //listInvoice = context.invoices.Include(x => x.Test).Include(y => y.Test.Appointment).ToList();
                    listInvoice = context.invoices.ToList();
                    if (listInvoice.Count == 0)
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listInvoice;
        }
        public static Invoice FindInvoiceById(int invId)
        {
            Invoice i = new Invoice();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    i = context.invoices.SingleOrDefault(x => x.InvoiceId == invId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return i;
        }
        public static void CreateInvoice(Invoice i)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.invoices.Add(i);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateInvoice(Invoice i)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Invoice>(i).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteInvoice(Invoice i)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var p1 = context.invoices.SingleOrDefault(c => c.InvoiceId == i.InvoiceId);
                    context.invoices.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static List<Invoice> GetByDate(DateTime startDate, DateTime endDate)
        {
            var i = new List<Invoice>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    //i = invoice.Where(i => i.OrderDate >= startDate && o.OrderDate <= endDate).ToList();
                    i = context.invoices.Include(x => x.Test.AppointmentId)
                        .Where(y => y.Test.Appointment.DateCreated >= startDate && y.Test.Appointment.DateCreated <= endDate)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return i;
        }
        //ĐANG LỖI
        /*public static List<Invoice> GetInvoiceByUser(string email)
        {
            var listOrder = new List<Order>();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var member = context.members.FirstOrDefault(x => x.Email == email);
                    if (member == null) return null;
                    listOrder = context.orders.Where(x => x.MemberId == member.MemberId).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrder;
        }*/
    }
}
