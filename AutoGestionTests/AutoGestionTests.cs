    using System;
using System.Collections.Generic;
using System.Linq;
using AutoGestion.Garage.Observer;
using AutoGestion.Vehicles.Builder;
using AutoGestion.Vehicles.Proxy;
using AutoGestion.Vehicles.State;
using AutoGestion.Vehicles.Template;
using AutoGestion.Vehicles.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoGestionTests
{
    [TestClass]
    public class AutoGestionTests
    {
        private PriceProxy _priceProxy;
        private Parc _parc;
        private CarBuilderDirector _carBuilderDirector;
        private TruckBuilderDirector _truckBuilderDirector;
        private List<Vehicle> _cars;
        private List<Vehicle> _trucks;
        private List<Vehicle> _vehicles;

        private void TestCleanup()
        {
            _priceProxy = new PriceProxy();
            _parc = new Parc();
            _carBuilderDirector = new CarBuilderDirector();
            _truckBuilderDirector = new TruckBuilderDirector();
            _cars = new List<Vehicle>();
            _trucks = new List<Vehicle>();
            _vehicles = new List<Vehicle>();
        }

        [TestMethod]
        public void Should_Build_100_Vehicles()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(50, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList();
            _trucks = _truckBuilderDirector.Build(50, VehicleEnums.Brands.Peugeot, VehicleEnums.Colors.White, 8000, 2, 3, 7000).ToList();
            _vehicles = _cars.Concat(_trucks).ToList();
            const int expectedVehicleCount = 100;

            Assert.IsTrue(_vehicles.Count == expectedVehicleCount);
        }

        [TestMethod]
        public void Should_Add_Vehicles_Into_Parc()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(50, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList();
            _trucks = _truckBuilderDirector.Build(50, VehicleEnums.Brands.Peugeot, VehicleEnums.Colors.White, 8000, 2, 3, 7000).ToList();
            _vehicles = _cars.Concat(_trucks).ToList();

            _parc.OrderVehicles(_vehicles);

            CollectionAssert.AreEqual(_vehicles, _parc.GetStoredVehicles());
        }

        [TestMethod]
        public void Should_Remove_All_Vehicles_From_Parc()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(50, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList();
            _trucks = _truckBuilderDirector.Build(50, VehicleEnums.Brands.Peugeot, VehicleEnums.Colors.White, 8000, 2, 3, 7000).ToList();
            _vehicles = _cars.Concat(_trucks).ToList();

            _parc.OrderVehicles(_vehicles);
            _parc.CancelVehiclesOrder();

            Assert.IsTrue(_parc.GetStoredVehicles().Count == 0);
        }

        [TestMethod]
        public void Should_Update_Transfert_State_To_Ordered()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(2, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList();
            foreach (Vehicle car in _cars)
            {
                car.UpdateTransfertState();
                Assert.IsTrue(car.TransfertState.GetTransfertStateType() == typeof(Ordered));
            }
        }

        [TestMethod]
        public void Should_Apply_Tva_On_Price()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(2, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList();
            const double tvaValue = 1.2;

            foreach (Vehicle vehicle in _cars)
            {
                double priceBeforeTva = vehicle.Price;
                vehicle.Price = _priceProxy.ComputeTaxe(vehicle.Price, tvaValue);
                Assert.IsTrue(Math.Abs(vehicle.Price - priceBeforeTva) > double.Epsilon);
            }
        }
    }
}
