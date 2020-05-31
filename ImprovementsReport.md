### Fixed Bugs ###
 1. Instructions are not user friendly. Like "Press ? for more instructions" doesn't seem like a good start. Changed it to a Welcome message.
 2. User Input c to get categories throws an exception. Reason- It was trying to access wrong url. right url is https://api.chucknorris.io/jokes/categories
        "Unhandled exception. System.AggregateException: One or more errors occurred. 404 error"
 3. Returned Categories are hard to read due to the formatting.
    [["animal","career","celebrity","dev","explicit","fashion","food","history","money","movie","music","political","religion","science","sport","travel"]]
 4. Get Random name Url seems to be outdated. The url http://uinames.com/api/ doesn't work. Replaced with   https://names.privserv.com/api/
 5. User can not enter a category option, even if User has entered "y" as response to the question "Want to specify a category?"
 6. Response for random name is being used for response to category selection
 6. Only one joke is displayed, even if User wishes to see more than one jokes
 7. There is no exit from the application.
 8. Instuction/ Questions are hard to read as they get embedded in response of the user.
    e.g - rWant to use a random name? y/n
 9. Invalid input throws an exception, but no friendly message that a user can understand

### Improvements in Code base ###

Console App <---> Helper Methods (Can be called as Manager or Controller) <-----> ExternalFeed methods (Providers)

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

4. Created Test Project "JokeCompany.JokeGenerator.Helpers.Tests" 

5. Created Test Project "JokeCompany.JokeGenerator.ExternalFeeds.Tests" 

