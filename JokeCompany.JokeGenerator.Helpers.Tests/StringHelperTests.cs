using System.Linq;
using NUnit.Framework;

namespace JokeCompany.JokeGenerator.Helpers.Tests
{
    [TestFixture]
    public class StringHelperTests
    {
        string fullText = "";
        int maxLength = 50;

        [Test]
        public void WordWrap_WithEmptyString_ReturnsSingleString()
        {
            fullText = "";
            var expectedStrings = StringHelper.WordWrap(fullText, maxLength);
            Assert.AreEqual(1, expectedStrings.Count());
        }

        [Test]
        public void WordWrap_WithLongString_ReturnsMultipleString()
        {
            fullText = "Chuck Norris facts are satirical factoids about American martial artist and actor Chuck Norris that have become an Internet phenomenon and as a result have become widespread in popular culture. The 'facts' are normally absurd hyperbolic claims about Norris' toughness, attitude, sophistication, and masculinity.";
            var expectedStrings = StringHelper.WordWrap(fullText, maxLength);
            Assert.AreEqual(7, expectedStrings.Count());
        }

         [Test]
        public void WordWrap_WithNull_ReturnsListOfNullElement()
        {
            var expectedStrings = StringHelper.WordWrap(null, maxLength);
            Assert.IsNull(expectedStrings.FirstOrDefault(), "Returned list of one null element");
        }

    }
}
