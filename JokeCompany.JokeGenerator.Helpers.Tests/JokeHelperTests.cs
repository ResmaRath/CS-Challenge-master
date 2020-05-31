using System;
using System.Linq;
using NUnit.Framework;
using JokeCompany.JokeGenerator.Helpers;

namespace JokeCompany.JokeGenerator.Helpers.Testscd
{
    [TestFixture]
    public class JokeHelperTests
    {
        JokeHelper _jokeHelper;
        string category = "food";

        [SetUp]
        public void SetUp()
        {
            _jokeHelper = new JokeHelper();
        }

        [Test]
        public void GetRandomJokes_JokeCountOne_ReturnsSingleJoke()
        {
            var joke = _jokeHelper.GetRandomJokes(1).ToList();
            Assert.AreEqual(1, joke.Count());
        }

        [Test]
        public void GetRandomJokes_JokeCountFive_ReturnsFiveJokes()
        {
            var joke = _jokeHelper.GetRandomJokes(5).ToList();
            Assert.AreEqual(5, joke.Count());
        }

        [Test]
        public void GetRandomJokes_SingleJokeWithCategory_ReturnsSingleJoke()
        {
            var joke = _jokeHelper.GetRandomJokes(1, category).ToList();
            Assert.AreEqual(1, joke.Count());
        }

        [Test]
        public void GetRandomJokes_FiveJokeWithCategory_ReturnsFiveJoke()
        {
            var joke = _jokeHelper.GetRandomJokes(5, category).ToList();
            Assert.AreEqual(5, joke.Count());
        }
    }
}
