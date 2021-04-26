using System;
using System.Collections.Generic;

#nullable disable

namespace HealthCare.Models
{
    public partial class PatientAddress
    {
        public PatientAddress()
        {
            Patients = new HashSet<Patient>();
        }

        public int AddressId { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string Eircode { get; set; }
        public string County { get; set; }
        public string City { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
