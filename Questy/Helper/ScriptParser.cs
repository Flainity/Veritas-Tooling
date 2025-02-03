using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Questy.Helper;

public class ScriptParser
{
    public static List<int> ExtractSayNumbers(string script)
    {
        var numbers = new List<int>();
        const string pattern = @"SAY\s+(\d+)";
        var matches = Regex.Matches(script, pattern);

        foreach (Match match in matches)
        {
            if (int.TryParse(match.Groups[1].Value, out int number))
            {
                numbers.Add(number);
            }
        }

        return numbers;
    }
}