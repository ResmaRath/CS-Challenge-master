1.  Naming appropriately is very important. I have changed the following names.
   - Renamed ConsoleApp1 namespace to JokeCompany.JokeGenerator.ConsoleApp namespace 
   - Renamed ConsoleApp1 Folder to JokeCompany.JokeGenerator.ConsoleApp Folder
   - Renamed Program.cs to JokeGenerator.cs

2. Created class library "JokeCompany.JokeGenerator.Helpers" for Console helpers, String helpers and JokeHelpers (Its a manager class that talks to the Providers to get data, format it and return to frontend)

3. Created class library "JokeCompany.JokeGenerator.ExternalFeeds" for providers that talks to the external APIs and returns deserialized data
    - Created Common/AbstractJsonFeed.cs to handle the calls to any given external API and the HttpResponse.
    - Created Common/JsonFeedException.cs to handle exceptions
    - Created ChuckNorrisJokeProvider/* that contains the providers that returns the JokeText and Joke Categories
    - Created RandomNameProvider/* that contains the providers which returns random names

