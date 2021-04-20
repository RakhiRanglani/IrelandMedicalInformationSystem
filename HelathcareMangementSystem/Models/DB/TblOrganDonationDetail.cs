using System;
using System.Collections.Generic;

#nullable disable

namespace HealthcareMangementSystem.Models.DB
{
    public partial class TblOrganDonationDetail
    {
        public int OrganDonationId { get; set; }
        public int HospitalDonationId { get; set; }
        public DateTime EventDate { get; set; }
        public string EventDescription { get; set; }
        public string OrganDetails { get; set; }
    }
}
