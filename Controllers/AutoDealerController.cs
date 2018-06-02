using AutoTrader.Models;
using AutoTrader.Models.ViewModels.AutoDealer;
using AutoTrader.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AutoTrader.Controllers
{
    public class AutoDealerController : Controller
    {
        public VehicleService vehicleService;
        public AutoDealerController(VehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        public async Task<IActionResult> Index(IndexViewModel vm)
        {
            vm.Vehicles = await vehicleService.GetVehicles().ToListAsync();

            return View(vm);
        }

        public async Task<IActionResult> InsertVehicle(InsertVehicleViewModel vm)
        {
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(InsertVehicleViewModel vm)
        {
            // Validation
            if(!ModelState.IsValid)
            {
                vm.Message = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault().ErrorMessage;

                return RedirectToAction("InsertVehicle", vm);
            }

            Vehicle vehicle = new Vehicle()
            {
                CylinderVariant = vm.CylinderVariant,
                EngineCapacity = vm.EngineCapacity,
                Make = vm.Make,
                Model = vm.Model,
                Price = vm.Price,
                TopSpeed = vm.TopSpeed
            };

            await vehicleService.Insert(vehicle);
            
            return RedirectToAction("InsertVehicle",vm);
        }

        public async Task<IActionResult> UpdateVehicle(Guid VehicleId)
        {
            var vehicle = await vehicleService.GetVehicles()
                .Where(w => w.VehicleId.Equals(VehicleId))
                .FirstOrDefaultAsync();

            if(vehicle == null)
            {
                return RedirectToAction("Index",new IndexViewModel() { Message = "Invalid Vehicle ID" });
            }
            
            return View();
        }
    }
}