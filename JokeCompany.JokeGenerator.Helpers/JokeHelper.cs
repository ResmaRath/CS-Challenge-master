using System.Collections.Generic;
using JokeCompany.JokeGenerator.ExternalFeeds;

namespace JokeCompany.JokeGenerator.Helpers
{
    /// <summary>
    /// Provides jokes for JokeHelper."/>
    /// </summary>
    public class JokeHelper
    {
        private readonly IChuckNorrisJsonProvider _jokeFeed;
        private readonly IRandomNameProvider _randomNameFeed;

        public JokeHelper(IChuckNorrisJsonProvider jokeFeed, IRandomNameProvider randomNameFeed)
        {
            _jokeFeed = jokeFeed;
            _randomNameFeed = randomNameFeed;
        }

        public IEnumerable<string> GetRandomJokes(int jokeCount, string category = null, string nameToReplace = null)
        {
            var useReplacementName = nameToReplace != null;
            var replacementName = useReplacementName ? _randomNameFeed.GetRandomFullName() : null;

            for (var i = 0; i < jokeCount; i++)
            {
                var result = _jokeFeed.GetRandomJoke(category);

                var finalJoke = useReplacementName ? result.Replace(nameToReplace, replacementName) : result;

                yield return finalJoke; // Return jokes as we get them for nicer UX.
            }
        }

        public IEnumerable<string> GetCategories()
        {
            return _jokeFeed.GetCategories();
        }
    }
}