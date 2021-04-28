using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.ViewModel
{
    [Keyless]
    public class MedicineViewModel
    {
        public string HospitalName { get; set; }
        public string Medicine_Name { get; set; }

        public string pharmacyAddress { get; set; }

        public string HospitalID { get; set; }

        public string Medicine_Availability { get; set; }
        public string pharmacyName { get; set; }
        public string pharmacyContactNo { get; set; }

        public List<MedicineViewModel> Medicinelist { get; set; }
    }
}
