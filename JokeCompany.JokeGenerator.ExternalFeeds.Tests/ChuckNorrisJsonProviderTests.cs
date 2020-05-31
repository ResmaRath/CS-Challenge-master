using System.Linq;
using NUnit.Framework;

namespace JokeCompany.JokeGenerator.ExternalFeeds.Tests
{
    [TestFixture]
    public class ChuckNorrisJsonProviderTests
    {
        ChuckNorrisJsonProvider _chuckNorrisJsonProvider;
        [SetUp]
        public void Setup()
        {
            _chuckNorrisJsonProvider = new ChuckNorrisJsonProvider();
        }

        [Test]
        public void GetRandomJoke_WithNoCategory_ReturnsChuckNorrisJoke()
        {
            var joke = _chuckNorrisJsonProvider.GetRandomJoke(null);
            Assert.IsNotNull(joke, "Returned a joke.");
            StringAssert.Contains("Chuck Norris", joke);
        }

        [Test]
        public void GetRandomJoke_WithCategory_ReturnsChuckNorrisJoke()
        {
            var joke = _chuckNorrisJsonProvider.GetRandomJoke("food");
            Assert.IsNotNull(joke, "Returned a joke in food category");
            StringAssert.Contains("Chuck Norris", joke);
        }

        [Test]
        public void GetCategories_ReturnsListIsNotEmpty()
        {
            var categories = _chuckNorrisJsonProvider.GetCategories();
            Assert.IsNotEmpty(categories);
        }
    }
}