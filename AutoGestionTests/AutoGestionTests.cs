using System;
using System.Collections.Generic;
using System.Linq;
using AutoGestion.Entities;
using AutoGestion.Providers.TransferState.States;
using AutoGestion.Utils;
using AutoGestion.Vehicles.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoGestionTests
{
    [TestClass]
    public class AutoGestionTests
    {
        private Park _park;
        private CarBuilderDirector _carBuilderDirector;
        private TruckBuilderDirector _truckBuilderDirector;
        private List<Vehicle> _cars;
        private List<Vehicle> _trucks;
        private List<Vehicle> _vehicles;

        private void TestCleanup()
        {
            _park = new Park();
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
        public void Should_Transfer_Arrived_Vehicles_Into_Parc()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(50, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList();
            _trucks = _truckBuilderDirector.Build(50, VehicleEnums.Brands.Peugeot, VehicleEnums.Colors.White, 8000, 2, 3, 7000).ToList();
            _vehicles = _cars.Concat(_trucks).ToList();

            _park.OrderVehicles(_vehicles);

            CollectionAssert.AreEqual(_vehicles, _park.GetOwnedVehicles());
        }

        [TestMethod]
        public void Should_Not_Transfer_OnTheWay_Vehicles_Into_Parc()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(50, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList();
            _trucks = _truckBuilderDirector.Build(50, VehicleEnums.Brands.Peugeot, VehicleEnums.Colors.White, 8000, 2, 3, 7000).ToList();
            _vehicles = _cars.Concat(_trucks).ToList();

            _park.OrderVehicles(_vehicles); // Vehicles are available

            //_park.UpdateVehiclesTransferState(); // Vehicles have been ordered by the parc
            //_park.UpdateVehiclesTransferState(); // Vehicles are on the way to the parc

            CollectionAssert.AreEqual(_vehicles, _park.GetOwnedVehicles());
        }

        [TestMethod]
        public void Should_Sell_Trucks()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(50, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList();
            _trucks = _truckBuilderDirector.Build(50, VehicleEnums.Brands.Peugeot, VehicleEnums.Colors.White, 8000, 2, 3, 7000).ToList();
            _vehicles = _cars.Concat(_trucks).ToList();

            //_park.UpdateVehiclesTransferState();

            _park.OrderVehicles(_vehicles);

            int oldVehiclesCount = _park.GetOwnedVehicles().Count;

            

            _park.SellVehicles(typeof(Truck), 40);

            int newVehiclesCount = _park.GetOwnedVehicles().Count;

            Assert.IsTrue(oldVehiclesCount - _trucks.Count == newVehiclesCount);
        }

        [TestMethod]
        public void Should_Update_Transfert_State_To_Ordered()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(2, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList();

            foreach (Vehicle car in _cars)
            {
                //car.UpdateTransfertState();
                Assert.IsTrue(car.TransfertState.State is Ordered);
            }
        }

        /*[TestMethod]
        public void Should_Apply_Tva_On_Price()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(2, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList();
            const double tvaValue = 1.2;

            foreach (Vehicle vehicle in _cars)
            {
                double priceBeforeTva = vehicle.Pricer;
                vehicle.Pricer = PricerProxy.ComputeTaxe(vehicle.Pricer, tvaValue);
                Assert.IsTrue(Math.Abs(vehicle.Pricer - priceBeforeTva) > double.Epsilon);
            }
        }*/
    }
}
