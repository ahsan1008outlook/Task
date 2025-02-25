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
        double lastSkip = 0;
        double carryForward = 0;
        for (int i = 0; i < totalGrades; i++)
        {
            if (grades[i].PercentageToAssign == 0) continue;
            double percentage = grades[i].PercentageToAssign / 100;
            double distribution = percentage * totalEmployees;

            int toTaken = ConvertToIntReq(distribution + carryForward);
            int toSkip = ConvertToIntReq(lastSkip);

            if (toTaken >= 1)
            {
                var setOfEmployee = employees.Skip(toSkip).Take(toTaken);
                foreach (var emp in setOfEmployee)
                {
                    emp.Grade = grades[i].Name;
                    emp.GradeRank = grades[i].Rank;
                }
                employeesNew.AddRange(setOfEmployee);
                // Console.WriteLine("Take {0} Skip {1} LastSkip {2} Per% {3} Dist {4} carryForward {5}", toTaken, toSkip, lastSkip, percentage, distribution, carryForward);

            }
            // Handle Carry Forward Decimals
            {
                if (toTaken > distribution)
                    carryForward += distribution - toTaken;
                else if (toTaken < distribution)
                    carryForward += distribution - toTaken;
            }


            lastSkip += distribution;
        }

        foreach (var emp in employeesNew)
        {
            Console.WriteLine($"{emp.Name} - Grade: {emp.Grade}, Rank: {emp.GradeRank}");
        }
        Console.WriteLine("Total Skip = " + lastSkip);
        Console.WriteLine("Total Employee = " + employeesNew.Count);
        return true;
    }
}