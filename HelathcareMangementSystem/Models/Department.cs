using System;
using System.Collections.Generic;

#nullable disable

namespace HealthcareMangementSystem.Models
{
    public partial class Department
    {
        public int Id { get; set; }
        public string SpecialtyDescription { get; set; }
        public int? HospitalId { get; set; }
        public int NumberofStaff { get; set; }
        public string DepartmentHead { get; set; }

        public virtual TblHospital Hospital { get; set; }
    }
}
