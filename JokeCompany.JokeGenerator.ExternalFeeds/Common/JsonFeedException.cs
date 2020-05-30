using System;

namespace JokeCompany.JokeGenerator.ExternalFeeds
{
    public class JsonFeedException : Exception
    {
        public JsonFeedException(string message, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}