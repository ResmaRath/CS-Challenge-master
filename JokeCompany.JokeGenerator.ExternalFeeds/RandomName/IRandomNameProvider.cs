namespace JokeCompany.JokeGenerator.ExternalFeeds
{
    public interface IRandomNameProvider
    {
        // Generates a random full name.
        string GetRandomFullName();
    }
}