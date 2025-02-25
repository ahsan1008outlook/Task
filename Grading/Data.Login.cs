namespace MyConsoleApp;
public static partial class Data
{
    public static List<Employee> AssignGrades(List<Employee> employees, List<Grade> grades)
    {
        int totalEmployees = employees.Count;
        int totalGrades = grades.Count;
        double percentage = totalGrades / 100.00;
        double distribution = totalEmployees * percentage; // Number of employees in this grade

        // var result = GradesGreaterThanEmployee(employees, grades);
        // if (result.Count > 0) return result;

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
        Console.WriteLine("lastSkip " + lastSkip);
        Console.WriteLine("Total " + employeesNew.Count);
        return employeesNew;
    }

    private static List<Employee> GradesGreaterThanEmployee(List<Employee> employees, List<Grade> grades)
    {
        bool noGrading = grades.Count > employees.Count;
        if (noGrading) new List<Employee>();

        int i = 0;
        foreach (var emp in employees)
        {
            emp.Grade = grades[i].Name;
            emp.GradeRank = grades[i].Rank;
            i++;
        }
        return employees;
    }
}