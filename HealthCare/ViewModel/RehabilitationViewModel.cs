using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.ViewModel
{
    public class RehabilitationViewModel
    {
        public string RehabilitationType { get; set; }

        public string CentreDetails { get; set; }

        public string AvailabilityDetails { get; set; }

        public string HospitalName { get; set; }

        public string LocationID { get; set; }

        public string City { get; set; }

        public List<RehabilitationViewModel> Rehablist { get; set; }


    }
}
