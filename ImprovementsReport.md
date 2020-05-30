1.  Naming appropriately is very important
   - Renamed ConsoleApp1 namespace to JokeCompany.JokeGenerator namespace 
   - Renamed ConsoleApp1 Folder to JokeCompany.JokeGenerator Folder
   - Renamed Program.cs to JokeGenerator.cs
   
2. Created class library "JokeCompany.JokeGenerator.Helpers" for Console helpers, String helpers and JokeHelpers (Its a manager class that talks to the Providers to get data, format it and return to frontend)

3. Created class library "JokeCompany.JokeGenerator.ExternalFeeds" for providers that talks to the external APIs and returns deserialized data
