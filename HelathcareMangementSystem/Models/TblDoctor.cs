using System;
using System.Collections.Generic;

#nullable disable

namespace HealthcareMangementSystem.Models
{
    public partial class TblDoctor
    {
        public int DoctorId { get; set; }
        public int DepartmentId { get; set; }
        public string DoctorName { get; set; }
        public int? HospitalId { get; set; }
        public string EducationalDetails { get; set; }
    }
}
