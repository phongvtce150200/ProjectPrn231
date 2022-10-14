using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PrescriptionDAO
    {
        public static List<Prescription> GetPrescription()
        {
            var listInvoice = new List<Prescription>();

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    //listInvoice = context.invoices.Include(x => x.Test).Include(y => y.Test.Appointment).ToList();
                    listInvoice = context.prescriptions.ToList();
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
        public static Prescription FindPrescriptionById(int Id)
        {
            Prescription prescription = new();
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    prescription = context.prescriptions.SingleOrDefault(x => x.PrescriptionId == Id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return prescription;
        }
        public static void CreatePrescription(Prescription prescription)
        {
            try
            {
                using var context = new ApplicationDbContext();
                context.prescriptions.Add(prescription);
                context.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdatePrescription(Prescription prescription)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry<Prescription>(prescription).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeletePrescription(Prescription prescription)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var p1 = context.prescriptions.SingleOrDefault(c => c.PrescriptionId == prescription.PrescriptionId);
                    context.prescriptions.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
