using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HealthcareMangementSystem.Models.DB;
using Microsoft.Extensions.Logging;

namespace HealthcareMangementSystem.Pages
{
    public class HealthInformation : PageModel
    {
        private readonly ILogger<HealthInformation> _logger;

        public HealthInformation(ILogger<HealthInformation> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
