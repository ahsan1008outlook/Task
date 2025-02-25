namespace MyConsoleApp;
public static partial class Data
{
    private static int ConvertToIntReq(double value)
    {
        int toSkip = (int)Math.Round(value);
        if (value % 1 == 0.5)
            toSkip = (int)Math.Ceiling(value);
        return toSkip;
    }
    public static bool AssignGrades2(List<Employee> employees, List<Grade> grades)
    {
        int totalEmployees = employees.Count;
        int totalGrades = grades.Count;

        bool result = GradesGreaterThanEmployee(employees, grades);
        if (result) return result;

        List<Employee> employeesNew = new List<Employee>();
        double lastSkip = 0; // 0, 3.8, 7.6, 11.4, 15.2, 19, 22.8, 26.6
        double carryForward = 0;
        for (int i = 0; i < totalGrades; i++)
        {
            if (grades[i].PercentageToAssign == 0) continue;

            double percentage = grades[i].PercentageToAssign / 100;
            double distribution = percentage * totalEmployees;
            // 1.5,    3    2.25    1.5     1.5     2.25    1.5     .75     .75
            // -.5,    -.5  -.25    -.75    -1.5    -1.25   -2.25   
            // 2,      3    2        
            int toTaken = ConvertToIntReq(distribution + carryForward);
            int toSkip = ConvertToIntReq(lastSkip);

            if (toTaken >= 1)
            {
                var setOfEmployee = employees.Skip(toSkip).Take(toTaken);
                Console.WriteLine("Take {0} Skip {1} LastSkip {2} Per% {3} Dist {4} carryForward {5}", toTaken, toSkip, lastSkip, percentage, distribution, carryForward);

                foreach (var emp in setOfEmployee)
                {
                    emp.Grade = grades[i].Name;
                    emp.GradeRank = grades[i].Rank;
                }
                employeesNew.AddRange(setOfEmployee);
            }
            if(toTaken > distribution)
            carryForward += distribution - toTaken;
            else if(toTaken < distribution)
            carryForward += distribution - toTaken;

            lastSkip += distribution;
        }
        Console.WriteLine("Total " + lastSkip);

        // Print the results
        foreach (var emp in employeesNew)
        {
            Console.WriteLine($"{emp.Name} - Grade: {emp.Grade}, Rank: {emp.GradeRank}");
        }
        Console.WriteLine("Total " + employeesNew.Count);
        return true;
    }
}