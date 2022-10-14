using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPrescriptionRepository
    {
        List<Prescription> GetAllPrescription();
        Prescription GetPrescriptionById(int id);
        void CreatePrescription(Prescription p);
        void UpdatePrescription(Prescription p);
        void DeletePrescription(Prescription p);
    }
}
