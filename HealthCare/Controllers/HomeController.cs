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
        public IActionResult covidtimeline()
        {
            return View();
        }
        public IActionResult Careers(CareerSearchVieModel model)
        {
            if (String.IsNullOrEmpty(model.HospitalName) && String.IsNullOrEmpty(model.City))
            {
                model = new CareerSearchVieModel()
                {
                    careerlist = new List<CareerSearchVieModel>(),
                };
            }
            else
            {
                string hospitalname = model.HospitalName;
                string city = model.City;

                model.careerlist = _context.GetCareerDetails.FromSqlInterpolated($"getCareerdetails {hospitalname},{city}").ToList();
            }
            return View(model);
        }
        public IActionResult PatientHistory(PatientHistoryViewModel model)
        {
            if (model.PatientID <= 0)
            {
                model = new PatientHistoryViewModel()
                {
                    patientlist = new List<PatientHistoryViewModel>(),
                };
            }
            else
            {
                int patientId = model.PatientID;
                model.patientlist = _context.GetPatientHistoryDetails.FromSqlInterpolated($"getPatientHistoryData {patientId}").ToList();

            }
            return View(model);
        }
        public IActionResult Rehab(RehabilationViewModel model)
        {
            try
            {
                model.rehabilationlist = _context.GetRehabInfo.FromSqlInterpolated($"Rehabilitation").ToList();

            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            return View(model);
        }
        public IActionResult HospitalSearch(HospitalSearchViewModel model)
        {
            if (String.IsNullOrEmpty(model.HospitalType) && String.IsNullOrEmpty(model.City))
            {
                model = new HospitalSearchViewModel()
                {
                    Hospitallist = new List<HospitalSearchViewModel>(),
                };
            }
            else
            {
                string param1 = model.HospitalType;
                string param2 = model.City;

                model.Hospitallist = _context.Getghospitaltype.FromSqlInterpolated($"Getgospitaltype {param1},{param2}").ToList();

            }
            return View(model);

        }

        public IActionResult MedicalSearch(MedicineViewModel model)
        {
            if (String.IsNullOrEmpty(model.Medicine_Name))
            {
                model = new MedicineViewModel()
                {
                    Medicinelist = new List<MedicineViewModel>(),
                };
            }
            else
            {
                string medicinename = model.Medicine_Name;
                if (medicinename != null)
                {
                    model.Medicinelist = _context.GetMedicineAvailability.FromSqlInterpolated($"MedicineAvailability {medicinename}").ToList();
                }
                else
                {
                    model = new MedicineViewModel()
                    {
                        Medicinelist = new List<MedicineViewModel>(),
                    };
                }
            }
            return View(model);

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
