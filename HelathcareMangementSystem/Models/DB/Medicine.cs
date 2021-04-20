using System;
using System.Collections.Generic;

#nullable disable

namespace HealthcareMangementSystem.Models.DB
{
    public partial class Medicine
    {
        public string MedicineId { get; set; }
        public int? HospitalId { get; set; }
        public int CourseLeve { get; set; }
        public int? CourseDurationMonths { get; set; }

        public virtual TblHospital Hospital { get; set; }
    }
}
