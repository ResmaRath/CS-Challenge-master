using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JokeCompany.JokeGenerator.Helpers
{
    public class ConsoleHelper
    {
        private const string InvalidSelection = "Invalid selection.";

        public enum Response
        {
            Yes,
            No
        }

        private readonly Regex _regexNo = new Regex(@"^\s*[Nn]([Oo])?\s*$", RegexOptions.Compiled);
        private readonly Regex _regexYes = new Regex(@"^\s*[Yy]([Ee][Ss])?\s*$", RegexOptions.Compiled);

        public ConsoleHelper(Encoding encoding)
        {
            Console.OutputEncoding = encoding;
        }
        public void PrintResults(IEnumerable<string> results)
        {
            if (results == null)
            {
                throw new ArgumentNullException(nameof(results));
            }

            var windowWidth = GetWindowWidth();

            foreach (var result in results.Where(r => r != null))
            {
                foreach (var line in result.WordWrap(windowWidth))
                {
                    WriteLine(line);
                }

                WriteEmptyLine();
            }

            WriteEmptyLine();
        }

        public string PromptForListSelection(string header, IEnumerable<string> possibleAnswers)
        {
            if (string.IsNullOrWhiteSpace(header))
            {
                throw new ArgumentException("No header was provided.", nameof(header));
            }

            var sortedAnswers = possibleAnswers?.Where(p => p != null).OrderBy(p => p).ToList() ?? new List<string>();

            if (sortedAnswers?.Any() != true)
            {
                throw new ArgumentException("No answers were provided to choose from.", nameof(sortedAnswers));
            }

            while (true)
            {
                WriteLine(header);

                for (var i = 0; i < sortedAnswers.Count; i++)
                {
                    WriteLine($"{i + 1} - {sortedAnswers[i]}");
                }

                WriteLine("Please choose by entering the name or the corresponding number:");
                var answer = ReadLine();

                if (!string.IsNullOrWhiteSpace(answer))
                {
                    answer = answer.Trim();

                    if (int.TryParse(answer, out var index))
                    {
                        if (sortedAnswers.Count >= index && index > 0)
                        {
                            return sortedAnswers[index - 1]; // Adjust because we started at 1 instead of 0.
                        }
                    }
                    else
                    {
                        var match = sortedAnswers.FirstOrDefault(a => a.Equals(answer, StringComparison.InvariantCultureIgnoreCase));

                        if (match != default)
                        {
                            return match;
                        }
                    }
                }

                WriteLine(InvalidSelection);
            }
        }

        public bool IsResponseYes(string prompt)
        {
            return PromptYesNo(prompt) == Response.Yes;
        }

        public byte PromptForDigit(string prompt)
        {
            ValidatePrompt(prompt);

            byte? response = null;

            while (!response.HasValue)
            {
                WriteLine($"{prompt} (1-9)");
                var line = ReadLine();

                response = GetSingleDigit(line);

                if (!response.HasValue)
                {
                    WriteLine(InvalidSelection);
                }
            }

            Console.Clear();

            return response.Value;
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void ShowActivityIndicator()
        {
            Console.WriteLine("Please Wait...");
        }

        private int GetWindowWidth()
        {
            return Console.WindowWidth;
        }

        private string ReadLine()
        {
            return Console.ReadLine();
        }

        private void WriteEmptyLine()
        {
            WriteLine(string.Empty);
        }

        private byte? GetSingleDigit(string line)
        {
            var isNullOrWhiteSpace = string.IsNullOrWhiteSpace(line);

            if (!isNullOrWhiteSpace)
            {
                if (byte.TryParse(line.Trim(), out var parsedNumber) && parsedNumber > 0 && parsedNumber < 10)
                {
                    return parsedNumber;
                }
            }

            return default;
        }

        private Response PromptYesNo(string prompt)
        {
            ValidatePrompt(prompt);

            Response? response = null;

            while (!response.HasValue)
            {
                WriteLine($"{prompt} y/n");
                var line = ReadLine();

                response = GetYesNoResponse(line);

                if (!response.HasValue)
                {
                    WriteLine(InvalidSelection);
                }
            }

            Console.Clear();

            return response.Value;
        }

        private Response? GetYesNoResponse(string line)
        {
            var isNullOrWhiteSpace = string.IsNullOrWhiteSpace(line);

            if (!isNullOrWhiteSpace)
            {
                if (_regexYes.IsMatch(line))
                {
                    return Response.Yes;
                }

                if (_regexNo.IsMatch(line))
                {
                    return Response.No;
                }
            }

            return default;
        }

        private void ValidatePrompt(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentException("No prompt was provided.", nameof(prompt));
            }
        }
    }
}