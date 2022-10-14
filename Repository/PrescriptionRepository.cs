using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
            public void CreatePrescription(Prescription p) => PrescriptionDAO.CreatePrescription(p);

            public void DeletePrescription(Prescription p) => PrescriptionDAO.DeletePrescription(p);

            public List<Prescription> GetAllPrescription() => PrescriptionDAO.GetPrescription();

            public Prescription GetPrescriptionById(int id) => PrescriptionDAO.FindPrescriptionById(id);

            public void UpdatePrescription(Prescription p) => PrescriptionDAO.UpdatePrescription(p);
    }
}
