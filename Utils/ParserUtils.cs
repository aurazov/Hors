using System;
using System.Collections.Generic;
using Hors.Dict;

namespace Hors.Utils
{
    internal static class ParserUtils
    {
        internal static void FixZeros(List<string> tokens)
        {
            var i = 0;
            while (i < tokens.Count - 1)
            {
                var current = tokens[i];

                if (current == "0" && tokens[i + 1].Length == 1 && int.TryParse(tokens[i + 1], out _))
                {
                    // this in zero and number after it, delete zero
                    tokens.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        internal static int FindIndex(string t, IList<string[]> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (Morph.HasOneOfLemmas(t, list[i]))
                    return i;
            }

            return -1;
        }

        internal static int GetYearFromNumber(int n)
        {
            // this is number less than 1000, what year it can be?
                
            if (n >= 70 && n < 100)
            {
                // for numbers from 70 to 99 this will be 19xx year
                return 1900 + n;
            }

            if (n < 1000)
            {
                // for other numbers 20xx or 2xxx year
                return 2000 + n;
            }
            
            return n;
        }

        internal static int GetDayValidForMonth(int year, int month, int day)
        {
            var daysInMonth = DateTime.DaysInMonth(year, month);
            return Math.Max(1, Math.Min(day, daysInMonth));
        }
    }
}