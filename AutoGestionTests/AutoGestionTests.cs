using System;
using System.Collections.Generic;
using System.Linq;
using AutoGestion.Entities;
using AutoGestion.Network;
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
        private Park _park = new Park();
        private Provider _provider = new Provider();
        private ParkNetwork _parkNetwork = new ParkNetwork();
        private PricerProxy _pricerProxy = new PricerProxy();
        private CarBuilderDirector _carBuilderDirector;
        private TruckBuilderDirector _truckBuilderDirector;
        private List<Vehicle> _cars;
        private List<Vehicle> _trucks;
        private List<Vehicle> _vehicles;

        private void TestCleanup()
        {
            _park = new Park();
            _provider = new Provider();
            _parkNetwork = new ParkNetwork();
            _pricerProxy = new PricerProxy();
            _carBuilderDirector = new CarBuilderDirector();
            _truckBuilderDirector = new TruckBuilderDirector();
            _cars = new List<Vehicle>();
            _trucks = new List<Vehicle>();
            _vehicles = new List<Vehicle>();

            _parkNetwork.AddParkToNetwork(_park);
            _parkNetwork.AddProviderToNetwork(_park, _provider);
        }
        

        [TestMethod]
        public void Should_Register_To_Park_Network()
        {
            TestCleanup();

            Assert.AreSame(_park.Network, _parkNetwork);
            Assert.AreSame(_provider.Network, _parkNetwork);
        }

        [TestMethod]
        public void Should_Build_Available_Vehicles()
        {
            TestCleanup();

            const int carsCount = 50;
            const int firstTrucksCount = 30;
            const int secondTrucksCount = 20;

            _cars = _carBuilderDirector.Build(carsCount, VehicleEnums.Brands.Renault, VehicleEnums.Colors.Black, 2000, 4, 5).ToList();

            _trucks = _truckBuilderDirector.Build(firstTrucksCount, VehicleEnums.Brands.Peugeot, VehicleEnums.Colors.White, 8000, 2, 3, 7000).ToList();

            _trucks.AddRange(_truckBuilderDirector.Build(secondTrucksCount));

            _vehicles = _cars.Concat(_trucks).ToList();

            Assert.IsTrue(_vehicles.Count == carsCount + firstTrucksCount + secondTrucksCount);
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

            var officialProviderAvailableVehicles = _park.Network.GetAvailableVehiclesFromProvider(_park, _provider).TrueForAll(v => v.TransfertState.State is Available);

            Assert.IsTrue(officialProviderAvailableVehicles);
        }

        [TestMethod]
        public void Should_Update_Transfert_State_To_Ordered()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(10).ToList();

            foreach (Vehicle car in _cars)
            {
                car.TransfertState.Update();
            }

            Assert.IsTrue(_cars.TrueForAll(v => v.TransfertState.State is Ordered));
        }

        [TestMethod]
        public void Should_Update_Transfert_State_To_OnTheWay()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(10).ToList();

            foreach (Vehicle car in _cars)
            {
                car.TransfertState.Update();
                car.TransfertState.Update();
            }

            Assert.IsTrue(_cars.TrueForAll(v => v.TransfertState.State is OnTheWay));
        }

        [TestMethod]
        public void Should_Update_Transfert_State_To_Arrived()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(10).ToList();

            foreach (Vehicle car in _cars)
            {
                car.TransfertState.Update();
                car.TransfertState.Update();
                car.TransfertState.Update();
            }

            Assert.IsTrue(_cars.TrueForAll(v => v.TransfertState.State is Arrived));
        }

        [TestMethod]
        public void Should_Update_Transfert_State_To_Stored()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(10).ToList();

            foreach (Vehicle car in _cars)
            {
                car.TransfertState.Update();
                car.TransfertState.Update();
                car.TransfertState.Update();
                car.TransfertState.Update();
            }

            Assert.IsTrue(_cars.TrueForAll(v => v.TransfertState.State is Stored));
        }

        [TestMethod]
        public void Should_Not_Update_Transfert_State_Anymore()
        {
            TestCleanup();

            _cars = _carBuilderDirector.Build(10).ToList();

            foreach (Vehicle car in _cars)
            {
                car.TransfertState.Update();
                car.TransfertState.Update();
                car.TransfertState.Update();
                car.TransfertState.Update();
                car.TransfertState.Update();
            }

            Assert.IsTrue(_cars.TrueForAll(v => v.TransfertState.State is Stored));
        }

        [TestMethod]
        public void Should_Apply_Tva_On_Vehicle_Price()
        {
            TestCleanup();

            var car = _carBuilderDirector.Build(5).First();

            double priceBeforeTva = car.Price;

            car.Price = _pricerProxy.ComputeTaxe(car.Price, car.GetTvaTax());

            Assert.IsTrue(Math.Abs(car.Price - priceBeforeTva) > double.Epsilon);
        }

        [TestMethod]
        public void Should_Receive_Vehicles_From_Provider()
        {
            TestCleanup();

            int oldVehiclesParkCount = _park.OwnedVehicles.Count;

            int providerCarCount = _park.Network.GetAvailableVehiclesFromProvider(_park, _provider).Where(v => v.GetType() == typeof(Car)).ToList().Count;
            int providerTruckCount = _park.Network.GetAvailableVehiclesFromProvider(_park, _provider).Where(v => v.GetType() == typeof(Truck)).ToList().Count;

            int providerVehicleCount = providerCarCount + providerTruckCount;

            _park.OrderAllVehicles(typeof(Car));
            _park.OrderAllVehicles(typeof(Truck));

            int newVehiclesParkCount = _park.OwnedVehicles.Count;

            Assert.IsTrue(oldVehiclesParkCount + providerVehicleCount == newVehiclesParkCount);
        }

        [TestMethod]
        public void Should_Sell_All_Trucks()
        {
            TestCleanup();

            _park.OrderAllVehicles(typeof(Truck));

            _park.SellAllVehicles(typeof(Truck));

            int trucksCount = _park.OwnedVehicles.Where(v => v.GetType() == typeof(Truck)).ToList().Count;

            Assert.IsTrue(trucksCount == 0);
        }
    }
}
