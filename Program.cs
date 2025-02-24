namespace MyConsoleApp;
class Program
{
   static void Main()
    {
        // List of Employees with random scores
        List<Employee> employees = Data.GenerateRandomEmployees(25).OrderBy(x => x.Score).ToList();
        List<Grade> grades = Data.GenerateGrade(5);

        // Assign grades to employees
        Data.AssignGrades(employees, grades);

        // // Display grouped results
        // var groupedEmployees = employees.OrderBy(e => e.GradeRank).GroupBy(e => e.Grade);
        // Console.WriteLine("Employee Grade Distribution:");
        // foreach (var group in groupedEmployees)
        // {
        //     Console.WriteLine($"\nGrade {group.Key}: Count {group.Count()}");
        //     foreach (var item in group)
        //     {
        //         Console.WriteLine($"Name: {item.Name} \tScore: {item.Score}");
        //     }
        // }
    }

  
}

      
        