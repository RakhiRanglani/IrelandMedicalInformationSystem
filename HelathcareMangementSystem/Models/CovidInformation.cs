using System;
using System.Collections.Generic;

#nullable disable

namespace HealthcareMangementSystem.Models
{
    public partial class CovidInformation
    {
        public string CovidId { get; set; }
        public string PatientId { get; set; }
        public DateTime CovidTestDate { get; set; }
        public string CovidStatus { get; set; }
    }
}
