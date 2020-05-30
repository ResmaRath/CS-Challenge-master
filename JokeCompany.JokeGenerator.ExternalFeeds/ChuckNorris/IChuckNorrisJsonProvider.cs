using System.Collections.Generic;

namespace JokeCompany.JokeGenerator.ExternalFeeds
{
    public interface IChuckNorrisJsonProvider
    {
        string GetRandomJoke(string category = null);
        IEnumerable<string> GetCategories();
    }
}