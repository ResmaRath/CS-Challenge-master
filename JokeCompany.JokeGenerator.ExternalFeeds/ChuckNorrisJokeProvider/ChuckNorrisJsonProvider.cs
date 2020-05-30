using System.Collections.Generic;
using System.Net.Http;

namespace JokeCompany.JokeGenerator.ExternalFeeds
{
    public class ChuckNorrisJsonProvider : AbstractJsonFeed, IChuckNorrisJsonProvider
    {

        public const string BaseUri = "https://api.chucknorris.io/";
        public const string RandomJokeEndpoint = "jokes/random";
        public const string CategoryToken = "{category}";
        public const string RandomJokeWithCategoryEndpoint = "jokes/random?category=" + CategoryToken;
        public const string AvailableCategoriesEndpoint = "jokes/categories";

        public ChuckNorrisJsonProvider(HttpMessageHandler handler = null) : base(BaseUri, handler)
        {
        }

        public string GetRandomJoke(string category)
        {
            var requestUri = category != null ?
                                 RandomJokeWithCategoryEndpoint.Replace(CategoryToken, category) :
                                 RandomJokeEndpoint;

            return GetDeserializedResponse<RandomJokeResponseDto>(requestUri).JokeText;
        }

        public IEnumerable<string> GetCategories()
        {
            return GetDeserializedResponse<List<string>>(AvailableCategoriesEndpoint);
        }
    }
}
