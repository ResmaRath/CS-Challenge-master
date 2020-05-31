using System.Linq;
using NUnit.Framework;

namespace JokeCompany.JokeGenerator.ExternalFeeds.Tests
{
    [TestFixture]
    public class RandomNameProviderTests
    {
        RandomNameProvider _randomNameProvider;
        [SetUp]
        public void Setup()
        {
            _randomNameProvider = new RandomNameProvider();
        }

        [Test]
        public void GetRandomFullName_ReturnsRandomName()
        {
            var name = _randomNameProvider.GetRandomFullName();
            Assert.IsNotNull(name, "Returned a name");
        }

        [Test]
        public void GetRandomNameResponse_ReturnsDto()
        {
            var dto = _randomNameProvider.GetRandomNameResponse();
            Assert.IsNotNull(dto, "Returned aDto");
        }
    }
}