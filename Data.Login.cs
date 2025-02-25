namespace MyConsoleApp;
public static partial class Data
{
    public static bool AssignGrades(List<Employee> employees, List<Grade> grades)
    {
        int totalEmployees = employees.Count;
        int totalGrades = grades.Count;
        double percentage = totalGrades / 100.00;
        double distribution = totalEmployees * percentage; // Number of employees in this grade

        bool result = GradesGreaterThanEmployee(employees, grades);
        if (result) return result;

        List<Employee> employeesNew = new List<Employee>();
        double lastSkip = 0;
        for (int i = 1; i <= totalGrades; i++)
        {
            int toSkip = (int)Math.Round(lastSkip);

            double toTake = (i * distribution) - toSkip;
            int toTaken = (int)Math.Round(toTake);

            var setOfEmployee = employees.Skip(toSkip).Take(toTaken);
            Console.WriteLine("Take {0} Skip {1}", toTaken, toSkip);
            lastSkip = i * distribution;


            foreach (var emp in setOfEmployee)
            {
                emp.Grade = grades[i - 1].Name;
                emp.GradeRank = grades[i - 1].Rank;
            }

            employeesNew.AddRange(setOfEmployee);
        }

        // Print the results
        foreach (var emp in employeesNew)
        {
            Console.WriteLine($"{emp.Name} - Grade: {emp.Grade}, Rank: {emp.GradeRank}");
        }
        Console.WriteLine("lastSkip " + lastSkip);
        Console.WriteLine("Total " + employeesNew.Count);
        return true;
    }

    private static bool GradesGreaterThanEmployee(List<Employee> employees, List<Grade> grades)
    {
        bool noEmployeeDistribution = grades.Count > employees.Count;
        if (noEmployeeDistribution)
        {
            int i = 0;
            foreach (var emp in employees)
            {
                emp.Grade = grades[i].Name;
                emp.GradeRank = grades[i].Rank;
                i++;
            }
        }
        return noEmployeeDistribution;
    }
}