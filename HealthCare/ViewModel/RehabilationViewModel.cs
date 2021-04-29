using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.ViewModel
{
    [Keyless]
    public class RehabilationViewModel
    {
     
        public string CentreDetails { get; set; }


        public string AvailabilityDetails { get; set; }
        public string RehabilitationType { get; set; }
        public string HospitalName { get; set; }

        public string City { get; set; }


        public List<RehabilationViewModel> rehabilationlist { get; set; }
    }
    
}
