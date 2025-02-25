namespace MyConsoleApp;
public static partial class Data
{
    public static void AssignGrades2(List<Employee> employees, List<Grade> grades)
    {
        int totalEmployees = employees.Count;
        double lastSkip = 0;
        int assignedCount = 0;

        foreach (var grade in grades)

        {
            if (grade.PercentageToAssign == 0) continue;
            
            double percentage = grade.PercentageToAssign / 100.0;
            double distribution = percentage * totalEmployees;

            int toTake = (int)Math.Round(distribution + lastSkip);
            toTake = Math.Min(toTake, totalEmployees - assignedCount); // Ensure we don't exceed available employees

            if (toTake > 0)
            {
                var setOfEmployees = employees.Skip(assignedCount).Take(toTake).ToList();
                foreach (var emp in setOfEmployees)
                {
                    emp.Grade = grade.Name;
                    emp.GradeRank = grade.Rank;
                }
                assignedCount += toTake;
            }
            Console.WriteLine("Take {0} Skip {1} LastSkip {2} Per% {3} Dist {4}", toTake, assignedCount, lastSkip, percentage, distribution );
            
            lastSkip += distribution - toTake; // Track rounding impact for the next iteration
        }

        // Print results
        foreach (var emp in employees)
        {
            Console.WriteLine($"{emp.Name} - Grade: {emp.Grade}, Rank: {emp.GradeRank}");
        }
        Console.WriteLine("employees.Count " + employees.Count);
        Console.WriteLine("lastSkip " + lastSkip);
        Console.WriteLine("assignedCount " + assignedCount);
        Console.WriteLine("totalEmployees " + totalEmployees);
    }
}