namespace MyConsoleApp;
public static partial class Data
{
    public static bool AssignGrades2(List<Employee> employees, List<Grade> grades)
    {
        int totalEmployees = employees.Count;
        int totalGrades = grades.Count;
      
        bool result = GradesGreaterThanEmployee(employees, grades);
        if (result) return result;

        List<Employee> employeesNew = new List<Employee>();
        double lastSkip = 0; // 0, 3.8, 7.6, 11.4, 15.2, 19, 22.8, 26.6
        for (int i = 1; i <= totalGrades; i++)
        {
            double percentage = 1.0 / grades[i -1].PercentageToAssign;
            double distribution = totalEmployees * percentage; // Number of employees in this grade

            int toSkip = (int)Math.Round(lastSkip); // 4, 8,

            double toTake = (i * distribution) - toSkip; // 4, 8,
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
        return true;
    }
}