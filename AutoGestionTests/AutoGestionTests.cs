using System;
using System.Collections.Generic;
using System.Linq;
using AutoGestion.Entities;
using AutoGestion.Prices;
using AutoGestion.TransferState.States;
using AutoGestion.Utils;
using AutoGestion.Vehicles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoGestionTests
{
    [TestClass]
    public class AutoGestionTests
    {
        private Park _park;
        private PricerProxy _pricerProxy = new PricerProxy();
        private CarBuilderDirector _carBuilderDirector;
        private TruckBuilderDirector _truckBuilderDirector;
        private List<Vehicle> _cars;
        private List<Vehicle> _trucks;
        private List<Vehicle> _vehicles;

        private void TestCleanup()
        {
            _park = new Park();
            _pricerProxy = new PricerProxy();
            _carBuilderDirector = new CarBuilderDirector();
            _truckBuilderDirector = new TruckBuilderDirector();
            _cars = new List<Vehicle>();
            _trucks = new List<Vehicle>();
            _vehicles = new List<Vehicle>();
        }

        [TestMethod]
        public void Should_Build_Available_Vehicles()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(50, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList();
            _trucks = _truckBuilderDirector.Build(50, VehicleEnums.Brands.Peugeot, VehicleEnums.Colors.White, 8000, 2, 3, 7000).ToList();

            _vehicles = _cars.Concat(_trucks).ToList();

            Assert.IsTrue(_vehicles.TrueForAll(v => v.TransfertState.State is Available));
        }

        [TestMethod]
        public void Should_Not_Possess_Vehicles_Which_Are_Not_Stored()
        {
            TestCleanup();

            _park.OrderAllVehicles(typeof(Car));

            Assert.IsTrue(_park.OwnedVehicles.TrueForAll(v => v.TransfertState.State is Stored));
        }

        [TestMethod]
        public void Should_Not_Possess_Vehicles_Which_Are_Not_Available()
        {
            TestCleanup();

            var officialProviderAvailableVehicles = _park.OfficialProvider.AvailableVehicles.TrueForAll(v => v.TransfertState.State is Available);

            Assert.IsTrue(officialProviderAvailableVehicles);
        }

        [TestMethod]
        public void Should_Receive_Vehicles_From_Provider()
        {
            TestCleanup();

            int oldVehiclesParkCount = _park.OwnedVehicles.Count;

            int providerCarCount = _park.OfficialProvider.AvailableVehicles.Where(v => v.GetType() == typeof(Car)).ToList().Count;
            int providerTruckCount = _park.OfficialProvider.AvailableVehicles.Where(v => v.GetType() == typeof(Truck)).ToList().Count;

            int providerVehicleCount = providerCarCount + providerTruckCount;

            _park.OrderAllVehicles(typeof(Car));
            _park.OrderAllVehicles(typeof(Truck));

            int newVehiclesParkCount = _park.OwnedVehicles.Count;

            Assert.IsTrue(oldVehiclesParkCount + providerVehicleCount == newVehiclesParkCount);
        }

        [TestMethod]
        public void Should_Update_Transfert_State_To_Ordered()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(10, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList();

            foreach (Vehicle car in _cars)
            {
                car.TransfertState.Update();
                Assert.IsTrue(car.TransfertState.State is Ordered);
            }
        }

        [TestMethod]
        public void Should_Sell_Trucks()
        {
            TestCleanup();

            _park.OrderAllVehicles(typeof(Truck));

            int oldTrucksCount = _park.OwnedVehicles.Where(v => v.GetType() == typeof(Truck)).ToList().Count;

            _park.SellAllVehicles(typeof(Truck));

            int newTrucksCount = _park.OwnedVehicles.Where(v => v.GetType() == typeof(Truck)).ToList().Count;

            Assert.IsTrue(oldTrucksCount - _trucks.Count == newTrucksCount);
        }

        [TestMethod]
        public void Should_Apply_Tva_On_Vehicle_Price()
        {
            TestCleanup();

            var car = _carBuilderDirector.Build(1, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).First();

            double priceBeforeTva = car.Price;

            car.Price = _pricerProxy.ComputeTaxe(car.Price, car.GetTvaTax());

            Assert.IsTrue(Math.Abs(car.Price - priceBeforeTva) > double.Epsilon);
        }
    }
}
