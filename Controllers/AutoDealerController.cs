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
            vm.Vehicles = await vehicleService.GetVehicles().OrderBy(o => o.Model).ToListAsync();

            return View(vm);
        }

        public IActionResult InsertVehicle()
        {
            return View();
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
            
            return View("InsertVehicle", new InsertVehicleViewModel() {
                CylinderVariant = vehicle.CylinderVariant,
                EngineCapacity = vehicle.EngineCapacity,
                Model = vehicle.Model,
                Make = vehicle.Make,
                Price = vehicle.Price,
                TopSpeed = vehicle.TopSpeed,
                VehicleId = vehicle.VehicleId
            });

            
        }

        [HttpPost]
        public async Task<IActionResult> Update(InsertVehicleViewModel vm)
        {
            var vehicle = await vehicleService.GetVehicles().Where(w => w.VehicleId.Equals(vm.VehicleId)).FirstOrDefaultAsync();
            if(vehicle == null)
            {
                return RedirectToAction("Index", new IndexViewModel() { Message = "Invalid Vehicle ID" });
            }

            if(!ModelState.IsValid)
            {
                return RedirectToAction("Update", new IndexViewModel() { Message = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault().ErrorMessage });
            }

            Vehicle updateVehicle = new Vehicle()
            {
                CylinderVariant = vm.CylinderVariant,
                EngineCapacity = vm.EngineCapacity,
                Make = vm.Make,
                Model = vm.Model,
                Price = vm.Price,
                TopSpeed = vm.TopSpeed,
                VehicleId = vm.VehicleId
            };

            try
            {
                await vehicleService.Update(updateVehicle);
            }
            catch(ArgumentException e)
            {
                return RedirectToAction("Update", new IndexViewModel() { Message = e.Message});
            }
            
            return RedirectToAction("Index", new IndexViewModel() { Message = "Invalid Vehicle ID" });
        }
    }
}