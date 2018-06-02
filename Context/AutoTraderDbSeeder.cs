using System;
using System.Linq;
using AutoTrader.Models;

namespace AutoTrader.Conntext
{
    public static class AutoTraderDbSeeder
    {
        public static void Init(this AutoTraderContext context)
        {
            // exit code
            if(context.Vehicles.Any())
            {
                return;
            }

            // Seeded Data
            var cars = new Vehicle[] {
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 6,
                     EngineCapacity = 2 ,
                     Make = "BMW",
                     Model = "5 Series",
                     Price = 111768.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 2,
                     EngineCapacity = 1.2,
                     Make = "Honda",
                     Model = "GSXR",
                     Price = 60000.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 1,
                     EngineCapacity = 1.3 ,
                     Make = "Honda",
                     Model = "5 Series",
                     Price = 111768.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 1,
                     EngineCapacity = 1000,
                     Make = "Suzuki",
                     Model = "GSXR",
                     Price = 60000.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 7,
                     EngineCapacity = 1.4 ,
                     Make = "Tesla",
                     Model = "5 Series",
                     Price = 111768.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 7,
                     EngineCapacity = 1.5,
                     Make = "Suzuki",
                     Model = "GSXR",
                     Price = 60000.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 6,
                     EngineCapacity = 1.6 ,
                     Make = "Mustang",
                     Model = "Charger",
                     Price = 111768.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 6,
                     EngineCapacity = 1.7,
                     Make = "Tesla",
                     Model = "GSXR",
                     Price = 60000.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 5,
                     EngineCapacity = 1.8 ,
                     Make = "BMW",
                     Model = "5 Series",
                     Price = 111768.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 5,
                     EngineCapacity = 1.9,
                     Make = "Volvo",
                     Model = "cruzer",
                     Price = 60000.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 3,
                     EngineCapacity = 2 ,
                     Make = "BMW",
                     Model = "5 Series",
                     Price = 111768.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 3,
                     EngineCapacity = 2.1,
                     Make = "Honda",
                     Model = "GSXR",
                     Price = 60000.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 2,
                     EngineCapacity = 1.2 ,
                     Make = "BMW",
                     Model = "4 Series",
                     Price = 111768.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 2,
                     EngineCapacity = 2.3,
                     Make = "Honda",
                     Model = "GSXR",
                     Price = 60000.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                   VehicleId = Guid.NewGuid(),
                     CylinderVariant = 10,
                     EngineCapacity = 2.4 ,
                     Make = "BMW",
                     Model = "3 Series",
                     Price = 111768.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 8,
                     EngineCapacity = 25,
                     Make = "Honda",
                     Model = "GSXR",
                     Price = 60000.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 6,
                     EngineCapacity = 1 ,
                     Make = "BMW",
                     Model = "2 Series",
                     Price = 111768.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 3,
                     EngineCapacity = 1.8,
                     Make = "Honda",
                     Model = "GSXR",
                     Price = 60000.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 4,
                     EngineCapacity = 1.5 ,
                     Make = "BMW",
                     Model = "Street fighter",
                     Price = 111768.00,
                     TopSpeed = 301.23
                },
                new Vehicle() {
                    VehicleId = Guid.NewGuid(),
                     CylinderVariant = 4,
                     EngineCapacity = 1.3,
                     Make = "Honda",
                     Model = "GSXR",
                     Price = 60000.00,
                     TopSpeed = 301.23
                },
            };

            context.Vehicles.AddRange(cars);
            context.SaveChanges();
            
        }
    }
}