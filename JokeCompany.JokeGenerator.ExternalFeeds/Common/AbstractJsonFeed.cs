using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JokeCompany.JokeGenerator.ExternalFeeds
{
    public abstract class AbstractJsonFeed
    {
        private readonly string _baseUri;
        protected internal HttpMessageHandler Handler { get; }

        protected AbstractJsonFeed(string baseUri, HttpMessageHandler handler = null)
        {
            _baseUri = baseUri;
            Handler = handler;
        }

        // Simple factory method which returns a new <see cref="HttpClient"/>. Will insert <see cref="Handler"/> if provided for unit testing.
        protected internal HttpClient GetHttpClient()
        {
            var client = Handler != null ? new HttpClient(Handler) : new HttpClient();
            client.BaseAddress = new Uri(_baseUri);
            
            return client;
        }

        // Gets a response from the JSON API and deserializes to the requested type <paramref name="T"/>.
        protected T GetDeserializedResponse<T>(string requestUri = "")
        {
            Task<string> result;

            using (var client = GetHttpClient())
            {
                try
                {
                    result = Task.FromResult(client.GetStringAsync(requestUri).Result);
                }
                catch (AggregateException e)
                {
                    var message = $"Failed to get response ({_baseUri}{requestUri}) "
                                    + "due to errors: {Environment.NewLine}{string.Join(Environment.NewLine, e.InnerExceptions.Select(i => i.Message))}";
                    
                    throw new JsonFeedException(message, e);
                }
            }

            if (result.IsCompletedSuccessfully)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(result.Result);
                }
                catch (JsonReaderException e)
                {
                    throw new JsonFeedException($"Failed to deserialize response ({_baseUri}{requestUri}) due to error: {e.Message}");
                }
            }
            else
            {

                throw new JsonFeedException($"Failed to get response from ({_baseUri}{requestUri}) due to unknown error.  " +
                                        $"IsCanceled: {result.IsCanceled} IsCompleted: {result.IsCompleted} IsFaulted: {result.IsFaulted}");
            }
        }
    }
}