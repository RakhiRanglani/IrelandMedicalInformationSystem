﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HealthCare.Models
{
    public partial class TblBloodDonationDetail
    {
        public int BloodDonationId { get; set; }
        public int HospitalId { get; set; }
        public DateTime EventDate { get; set; }
        public string BloodGroupDetails { get; set; }
    }
}
