using OceanicAirlinesWebApp.Algorithms;
using OceanicAirlinesWebApp.Models;

namespace UnitTest
{
    public class AlgorithmTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Dijkstra_returns_airline_route_time8()
        {

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 22, (e) => e.Time); 
            Assert.AreEqual(route.TotalTime, 8);
        }

        [Test]
        public void Dijkstra_returns_airline_route_time16()
        {
            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 29, (e) => e.Time);
            Assert.AreEqual(route.TotalTime, 16);
        }

        [Test]
        public void Dijkstra_returns_airline_route_time32()
        {

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Time);
            Assert.AreEqual(route.TotalTime, 32);
        }


        [Test]
        public void Dijkstra_return_price_SizeA()
        {

            Parcel parcel = new Parcel()
            {
                Height = 10,
                Width = 10,
                Length = 10,
                Weight = 3,
                Category = 0,
            };

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Price);
            route.CalculatePriceAndTime(parcel);
            Assert.AreEqual(route.TotalPrice, 60 );
        }

        [Test]
        public void Dijkstra_return_price_SizeB()
        {

            Parcel parcel = new Parcel()
            {
                Height = 10,
                Width = 35,
                Length = 10,
                Weight = 3,
                Category = 0,
            };

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Price);
            route.CalculatePriceAndTime(parcel);
            Assert.AreEqual(route.TotalPrice, 68);
        }


        [Test]
        public void Dijkstra_return_price_SizeC()
        {

            Parcel parcel = new Parcel()
            {
                Height = 10,
                Width = 150,
                Length = 10, 
                Weight = 3,
                Category = 0,
            };

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Price);
            route.CalculatePriceAndTime(parcel);
            Assert.AreEqual(route.TotalPrice, 100);
        }


        [Test]
        public void Dijkstra_return_price_SizeAnewWeight()
        {

            Parcel parcel = new Parcel()
            {
                Height = 10,
                Width = 10,
                Length = 10,
                Weight = 0.5,
                Category = 0,
            };

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Price);
            route.CalculatePriceAndTime(parcel);
            Assert.AreEqual(route.TotalPrice, 40);
        }

        [Test]
        public void Dijkstra_return_price_SizeBnewWeight()
        {

            Parcel parcel = new Parcel()
            {
                Height = 10,
                Width = 35,
                Length = 10,
                Weight = 7,
                Category = 0,
            };

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Price);
            route.CalculatePriceAndTime(parcel);
            Assert.AreEqual(route.TotalPrice, 88);
        }


        [Test]
        public void Dijkstra_return_price_SizeCnewWeight()
        {

            Parcel parcel = new Parcel()
            {
                Height = 10,
                Width = 150,
                Length = 10,
                Weight = 6,
                Category = 0,
            };

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Price);
            route.CalculatePriceAndTime(parcel);
            Assert.AreEqual(route.TotalPrice, 120);
        }


        [Test]
        public void Dijkstra_return_price_SizeACat3()
        {

            Parcel parcel = new Parcel()
            {
                Height = 10,
                Width = 10,
                Length = 10,
                Weight = 3,
                Category = 3,
            };

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Price);
            route.CalculatePriceAndTime(parcel);
            Assert.AreEqual(route.TotalPrice, 66);
        }

        [Test]
        public void Dijkstra_return_price_SizeBCat1()
        {

            Parcel parcel = new Parcel()
            {
                Height = 10,
                Width = 35,
                Length = 10,
                Weight = 3,
                Category = 1,
            };

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Price);
            route.CalculatePriceAndTime(parcel);
            Assert.AreEqual(route.TotalPrice, 0);
        }


        [Test]
        public void Dijkstra_return_price_SizeCCat7()
        {

            Parcel parcel = new Parcel()
            {
                Height = 10,
                Width = 150,
                Length = 10,
                Weight = 3,
                Category = 7,
            };

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Price);
            route.CalculatePriceAndTime(parcel);
            Assert.AreEqual(route.TotalPrice, 200);
        }

        [Test]
        public void Dijkstra_return_price_SizeACat6()
        {

            Parcel parcel = new Parcel()
            {
                Height = 10,
                Width = 10,
                Length = 10,
                Weight = 3,
                Category = 6,
            };

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Price);
            route.CalculatePriceAndTime(parcel);
            Assert.AreEqual(route.TotalPrice, 60);
        }

        [Test]
        public void Dijkstra_return_price_SizeBCat7()
        {

            Parcel parcel = new Parcel()
            {
                Height = 10,
                Width = 35,
                Length = 10,
                Weight = 3,
                Category = 7,
            };

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Price);
            route.CalculatePriceAndTime(parcel);
            Assert.AreEqual(route.TotalPrice, 136);
        }


        [Test]
        public void Dijkstra_return_price_SizeCCat5()
        {

            Parcel parcel = new Parcel()
            {
                Height = 10,
                Width = 150,
                Length = 10,
                Weight = 3,
                Category = 5,
            };

            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Price);
            route.CalculatePriceAndTime(parcel);
            Assert.AreEqual(route.TotalPrice, 175);
        }
    }
}