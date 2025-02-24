namespace MyConsoleApp;
public static partial class Data
{
    public static List<Employee> GenerateRandomEmployees(int count)
    {
        Random random = new Random();
        List<string> names = new List<string>
        {
            "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Hank", "Ivy", "Jack",
            "Kara", "Leo", "Mia", "Nate", "Olivia", "Paul", "Quinn", "Rachel", "Sam", "Tina",
            "Uma", "Victor", "Wendy", "Xander", "Yara", "Zane", "Liam", "Noah", "Emma", "Sophia",
            "Lucas", "Mason", "Isabella", "Ava", "Elijah", "James", "Charlotte", "Amelia"
        };

        return names.Select(name => new Employee
        {
            Name = name,
            Score = Math.Round(random.NextDouble() * 50 + 50, 1) // Generates a score between 50 and 100
        }).Take(count).ToList();
    }
    public static List<Grade> GenerateGrade(int count)
    {
        List<Grade> grades = new List<Grade>
        {
            new Grade { Name = "AA", Rank = 1, PercentageToAssign = 10 },
            new Grade { Name = "A+", Rank = 2, PercentageToAssign = 20 },
            new Grade { Name = "A", Rank = 3, PercentageToAssign = 15 },
            new Grade { Name = "B+", Rank = 4, PercentageToAssign = 10 },
            new Grade { Name = "B", Rank = 5, PercentageToAssign = 10 },
            new Grade { Name = "C", Rank = 6, PercentageToAssign = 15 },
            new Grade { Name = "E", Rank = 7, PercentageToAssign = 10 },
            new Grade { Name = "F", Rank = 8, PercentageToAssign = 5 },
            new Grade { Name = "G", Rank = 9, PercentageToAssign = 0 },
            new Grade { Name = "H", Rank = 10, PercentageToAssign = 5 }
        };
        return grades.Take(count).ToList();
    }


}