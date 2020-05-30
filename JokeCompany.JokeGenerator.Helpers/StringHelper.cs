using System;
using System.Collections.Generic;
using System.Linq;

namespace JokeCompany.JokeGenerator.Helpers
{
    public static class StringHelper
    {
        public static IEnumerable<string> WordWrap(this string fullText, int maxWidth)
        {

            if (string.IsNullOrWhiteSpace(fullText))
            {
                // All whitespace doesn't make much sense to request wrapping on, so we just return it as-is.
                return new[] { fullText };
            }

            var words = fullText.Split(' ');

            var wrappedLines = words.Skip(1).Aggregate(words.Take(1).ToList(), (lines, nextWord) =>
            {
                // Line would overflow, go to next line.
                if (lines.Last().Length + nextWord.Length >= maxWidth)
                {
                    lines.Add(nextWord);
                }
                else // Current line has capacity for the current word.
                {
                    lines[lines.Count - 1] += " " + nextWord;
                }

                return lines;
            });

            return wrappedLines;
        }
    }
}