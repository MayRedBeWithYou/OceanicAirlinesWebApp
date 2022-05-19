using OceanicAirlinesWebApp.Algorithms;
using OceanicAirlinesWebApp.Models;
namespace UnitTest
{
    public class ApiTests
    {

        [SetUp]
        public void Setup()
        {
            var result = Endpoints.FetchResultFromTL(new RequestDTO()
            {
                From = "Warsaw",
                To = "Paris"
            });
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}