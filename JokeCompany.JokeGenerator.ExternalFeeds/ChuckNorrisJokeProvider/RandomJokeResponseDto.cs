using Newtonsoft.Json;

namespace JokeCompany.JokeGenerator.ExternalFeeds
{
    public class RandomJokeResponseDto
    {
        [JsonProperty("value")]
        public string JokeText { get; set; }
    }
}