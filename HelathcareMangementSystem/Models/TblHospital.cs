using System;
using System.Collections.Generic;

#nullable disable

namespace HealthcareMangementSystem.Models
{
    public partial class TblHospital
    {
        public TblHospital()
        {
            Departments = new HashSet<Department>();
            Medicines = new HashSet<Medicine>();
            Vacancies = new HashSet<Vacancy>();
        }

        public int HospitalId { get; set; }
        public string HospitalType { get; set; }
        public string HospitalName { get; set; }
        public string HasBloodDonation { get; set; }
        public string HasOrganDonation { get; set; }
        public int? LocationId { get; set; }

        public virtual TblLocation Location { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
