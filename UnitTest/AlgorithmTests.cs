using OceanicAirlinesWebApp.Algorithms;

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
            Route route = graph.Dijkstra(2, 23, (e) => e.Time);
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
        public void Dijkstra_return_price32()
        {
            Graph graph = new Graph();
            Route route = graph.Dijkstra(2, 13, (e) => e.Price);
            Assert.AreEqual(route.TotalPrice, 32);

            //Assert.Fail();
        }


        [Test]
        public void Test2()
        {
            Assert.Fail();
        }
    }
}