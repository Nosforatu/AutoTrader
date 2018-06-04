using AutoTrader.Models.ViewModels.AirPressure;
using AutoTrader.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrader.Controllers
{
    public class ChartController : Controller
    {
        public VehicleService vehicleService;

        public ChartController(VehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult AirPressure()
        {
            AirPressureViewModel vm = new AirPressureViewModel();
            vm.QueryName = "Air Pressure";



            return new JsonResult(vm);
        }
    }
}
