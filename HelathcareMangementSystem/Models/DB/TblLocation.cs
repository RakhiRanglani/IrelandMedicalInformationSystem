using System;
using System.Collections.Generic;

#nullable disable

namespace HealthcareMangementSystem.Models.DB
{
    public partial class TblLocation
    {
        public TblLocation()
        {
            TblHospitals = new HashSet<TblHospital>();
        }

        public int LocationId { get; set; }
        public string City { get; set; }
        public string Eircode { get; set; }
        public string County { get; set; }

        public virtual ICollection<TblHospital> TblHospitals { get; set; }
    }
}
