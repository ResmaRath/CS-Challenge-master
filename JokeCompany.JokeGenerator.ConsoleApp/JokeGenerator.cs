using System;
using System.Text;
using JokeCompany.JokeGenerator.Helpers;

namespace JokeCompany.JokeGenerator.ConsoleApp
{
    public class JokeGenerator
    {
        private const string ChuckNorris = "Chuck Norris";
        private static ConsoleHelper _consoleHelper;
        private static JokeHelper _jokeHelper;

        static void Main()
        {
            _jokeHelper = new JokeHelper();
            _consoleHelper = new ConsoleHelper(Encoding.UTF8);

            DisplayIntroduction();
            GenerateJokes();
            DisplayEndMessage();
        }

        private static void GenerateJokes()
        {
            var needMoreJokes = true;
            while (needMoreJokes)
            {
                try
                {
                    var useReplacementName = _consoleHelper.IsResponseYes("Would you like to use a random name?");
                    var useCategory = _consoleHelper.IsResponseYes("Would you like to specify a category?");

                    var category = useCategory
                                 ? _consoleHelper.PromptForListSelection("Available categories:", _jokeHelper.GetCategories())
                                 : null;
                    var numberOfJokes = _consoleHelper.PromptForDigit("How many jokes would you like?");

                    _consoleHelper.ShowActivityIndicator();
                    var nameToReplace = useReplacementName
                                        ? ChuckNorris
                                        : null;
                    var jokes = _jokeHelper.GetRandomJokes(numberOfJokes, category, nameToReplace);
                    _consoleHelper.PrintResults(jokes);

                    needMoreJokes = _consoleHelper.IsResponseYes("Would you like more jokes?");
                }
                catch (Exception)
                {
                    _consoleHelper.WriteLine("Sorry, an error occurred. If this continues, please contact Joke Company support.");
                }

            }
        }

        private static void DisplayIntroduction()
        {
            _consoleHelper.WriteLine($"Welcome to Joke Company. Please follow the instruction to find some amaizing Chuck Norris jokes \n");
        }
        private static void DisplayEndMessage()
        {
            _consoleHelper.WriteLine("Thanks for using Joke Company's Joke Generator App. Hope to see you again!");
        }
    }
}
