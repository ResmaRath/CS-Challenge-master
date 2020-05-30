using System.Net.Http;

namespace JokeCompany.JokeGenerator.ExternalFeeds
{
    // Provides random names.
    public class RandomNameProvider : AbstractJsonFeed, IRandomNameProvider
    {
        private const string BaseUri = "https://names.privserv.com/api/";
        public RandomNameProvider(HttpMessageHandler handler = null) : base(BaseUri, handler)
        {
        }

        public string GetRandomFullName()
        {
            var response = GetRandomNameResponse();

            return $"{response.FirstName ?? string.Empty} {response.Surname ?? string.Empty}";
        }

        public NameResponseDto GetRandomNameResponse()
        {
            return GetDeserializedResponse<NameResponseDto>();
        }
    }
}