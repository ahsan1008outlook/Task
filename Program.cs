namespace MyConsoleApp;
class Program
{
   static void Main()
    {
        List<Employee> employees = Data.GenerateRandomEmployees(15).OrderByDescending(x => x.Score).ToList();
        List<Grade> grades = Data.GenerateGrade(10).OrderBy(x => x.Rank).ToList();
        Data.AssignGrades2(employees, grades);
    }

  
}

      
        