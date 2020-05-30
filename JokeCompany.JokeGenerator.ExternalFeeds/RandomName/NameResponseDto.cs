using Newtonsoft.Json;

namespace JokeCompany.JokeGenerator.ExternalFeeds
{
    /// <summary>
    /// DTO for responses from the random name API.
    /// </summary>
    public class NameResponseDto
    {
        [JsonProperty("name")]
        public string FirstName { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }
    }
}