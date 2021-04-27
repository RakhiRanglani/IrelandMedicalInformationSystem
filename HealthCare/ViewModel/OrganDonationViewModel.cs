using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.ViewModel
{
    [Keyless]
    public class OrganDonationViewModel
    {
        public DateTime EventDate { get; set; }
        public string EventDescription { get; set; }


        public string Organ { get; set; }
        public string AvailabilityInfo { get; set; }
        public string HasOrganDonation { get; set; }

        public string HospitalName { get; set; }

        public string City { get; set; }


        public string County { get; set; }

        public string EIRCode { get; set; }

        public List<OrganDonationViewModel> OrganDetailslist { get; set; }
    }
}
