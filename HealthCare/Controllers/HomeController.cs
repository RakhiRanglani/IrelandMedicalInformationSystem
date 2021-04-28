using HealthCare.Models;
using HealthCare.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IrelandHospitalContext _context;

        public HomeController(IrelandHospitalContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult HealthInformation()
        {
            return View();
        }
        public  IActionResult Rehab()
        {
            return View();
        }
        public IActionResult HospitalSearch(HospitalSearchViewModel model)
        {
             string param1 =model.HospitalType;
             string param2 = model.City;

            model.Hospitallist = _context.Getghospitaltype.FromSqlInterpolated($"Getgospitaltype {param1},{param2}").ToList();
            return View(model);

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
