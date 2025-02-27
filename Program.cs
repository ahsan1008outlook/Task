namespace MyConsoleApp;
class Program
{
    static void Main()
    {
        // List<Employee> employees = Data.GenerateRandomEmployees(15).OrderByDescending(x => x.Score).ToList();
        // List<Grade> grades = Data.GenerateGrade(10).OrderBy(x => x.Rank).ToList();

        // List<Employee> employeesNew = Data.AssignGrades2(employees, grades);

        // foreach (var emp in employeesNew)
        // {
        //     Console.WriteLine($"{emp.Name} - Grade: {emp.Grade}, Rank: {emp.GradeRank}");
        // }

        Logics.RegexCheck1();
    }
}