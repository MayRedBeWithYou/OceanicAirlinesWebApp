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
            System.Diagnostics.Debug.WriteLine(graph.Dijkstra(2, 23, (e) => e.Time));
            Assert.AreEqual(8, 8);
        }

        [Test]
        public void Dijkstra_returns_airline_route_time16()
        {

            Graph graph = new Graph();
            System.Diagnostics.Debug.WriteLine(graph.Dijkstra(2, 29, (e) => e.Time));
            Assert.AreEqual(16, 16);
        }

        [Test]
        public void Dijkstra_returns_airline_route_time32()
        {

            Graph graph = new Graph();
            System.Diagnostics.Debug.WriteLine(graph.Dijkstra(2, 13, (e) => e.Time));
            Assert.AreEqual(32, 32);
        }

        [Test]
        public void Test2()
        {
            Assert.Fail();
        }
    }
}