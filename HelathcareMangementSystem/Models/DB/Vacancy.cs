using System;
using System.Collections.Generic;

#nullable disable

namespace HealthcareMangementSystem.Models.DB
{
    public partial class Vacancy
    {
        public int VacancyId { get; set; }
        public int? HospitalId { get; set; }
        public string JobDetails { get; set; }
        public string JobAvailability { get; set; }

        public virtual TblHospital Hospital { get; set; }
    }
}
