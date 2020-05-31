using System.Collections.Generic;
using JokeCompany.JokeGenerator.ExternalFeeds;

namespace JokeCompany.JokeGenerator.Helpers
{
    /// <summary>
    /// Provides jokes for JokeHelper."/>
    /// </summary>
    public class JokeHelper
    {
        private ChuckNorrisJsonProvider _jokeFeed;
        private RandomNameProvider _randomNameFeed;

        public JokeHelper()
        {
            _jokeFeed = new ChuckNorrisJsonProvider();
            _randomNameFeed =  new RandomNameProvider();
        }

        public IEnumerable<string> GetRandomJokes(int jokeCount, string category = null, string nameToReplace = null)
        {
            var useReplacementName = nameToReplace != null;
            var replacementName = useReplacementName ? _randomNameFeed.GetRandomFullName() : null;

            for (var i = 0; i < jokeCount; i++)
            {
                var result = _jokeFeed.GetRandomJoke(category);

                var finalJoke = useReplacementName ? result.Replace(nameToReplace, replacementName) : result;

                yield return finalJoke;
            }
        }

        public IEnumerable<string> GetCategories()
        {
            return _jokeFeed.GetCategories();
        }
    }
}