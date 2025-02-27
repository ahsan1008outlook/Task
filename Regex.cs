using System.Text.RegularExpressions;

namespace MyConsoleApp;
public static partial class Logics
{
    public static new List<List<string>> RegexCheck1(string input = "(EmployeeId.Contains(\"19\")) AND FullName.Contains(\"Employee\")) OR (EmployeeId.Contains(\"17\")) AND !(EmployeeId.Contains(\"18\"))")
    {
        string pattern = @"(OR|AND|\s*)\s*(!?)\s*\(EmployeeId\.Contains\(\""(\d+)\""\)\)";

        MatchCollection matches = Regex.Matches(input, pattern);
        List<List<string>> extractedConditions = new List<List<string>>();

        foreach (Match match in matches)
        {
            string conditionType = match.Groups[1].Value; // OR or AND
            string negation = match.Groups[2].Value;      // "!" if present
            int number = int.Parse(match.Groups[3].Value); // Extracted numeric value

            // Build the structured list
            List<string> entry = new List<string> { conditionType };
            entry.Add(number.ToString());
            if (!string.IsNullOrEmpty(negation)) entry.Add(negation); // Add "!" if present

            extractedConditions.Add(entry);
        }
        foreach (var condition in extractedConditions)
        {
            Console.WriteLine(condition[1] + " " + condition[0] + " - " + (condition.Count == 3 ? condition[2] : "") );
        }

    
        string cleanedInput = Regex.Replace(input, pattern, "").Trim();
        return extractedConditions;

    }
}


