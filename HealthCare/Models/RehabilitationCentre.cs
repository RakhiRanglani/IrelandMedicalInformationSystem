using System;
using System.Collections.Generic;

#nullable disable

namespace HealthCare.Models
{
    public partial class RehabilitationCentre
    {
        public int RehabCentreId { get; set; }
        public int? HospitalId { get; set; }
        public string RehabilitationType { get; set; }
        public string CentreDetails { get; set; }
        public string EmailId { get; set; }
        public string AvailabilityDetails { get; set; }
    }
}
