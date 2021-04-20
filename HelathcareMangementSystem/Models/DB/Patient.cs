using System;
using System.Collections.Generic;

#nullable disable

namespace HealthcareMangementSystem.Models.DB
{
    public partial class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string CovidFlag { get; set; }
        public int? AddressId { get; set; }
        public int? AppHistoryId { get; set; }

        public virtual PatientAddress Address { get; set; }
        public virtual AppointmentHistory AppHistory { get; set; }
    }
}
