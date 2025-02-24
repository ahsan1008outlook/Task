﻿namespace MyConsoleApp;
public static class Data
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
            new Grade { Name = "AA", Rank = 1 },
            new Grade { Name = "A+", Rank = 2 },
            new Grade { Name = "A", Rank = 3 },
            new Grade { Name = "B+", Rank = 4 },
            new Grade { Name = "B", Rank = 5 },
            new Grade { Name = "C", Rank = 6 },
            new Grade { Name = "E", Rank = 7 },
            new Grade { Name = "F", Rank = 8 },
            new Grade { Name = "G", Rank = 9 },
            new Grade { Name = "H", Rank = 10 }
        };
        return grades.Take(count).ToList();
    }

    public static bool AssignGrades(List<Employee> employees, List<Grade> grades)
    {
        int totalEmployees = employees.Count;
        int totalGrades = grades.Count;
        double percentage = 1.0 / totalGrades;
        double distribution = totalEmployees * percentage; // Number of employees in this grade
        // bool noEmployeeDistribution = totalGrades > totalEmployees;
        // if(!noEmployeeDistribution) 
        // {
        //     foreach(var emp in employees)
        //     {
        //         emp.Grade = grades[i].Name;
        //         emp.GradeRank = grades[i].Rank;
        //     }
        //     return false;
        // }
        // Console.WriteLine("NoEmployeeDistribution: {0}", noEmployeeDistribution);


        List<Employee> employeesNew = new List<Employee>();

        Console.WriteLine("Total Employees: {0}", totalEmployees);
        Console.WriteLine("Total Grades: {0}", totalGrades);
        Console.WriteLine("Percentage Per Grade: {0}", percentage);
        Console.WriteLine("Employee Distribution Over Grades: {0}", distribution);

        double lastSkip = 0; // 0, 3.8, 7.6, 11.4, 15.2, 19, 22.8, 26.6
        for (int i = 1; i <= totalGrades; i++)
        {
            int toSkip = (int)Math.Round(lastSkip); // 4, 8,

            double toTake = (i * distribution) - toSkip; // 4, 8,
            int toTaken = (int)Math.Round(toTake);

            var setOfEmployee = employees.Skip(toSkip).Take(toTaken);
            Console.WriteLine("Take {0} Skip {1}", toTaken, toSkip);
            lastSkip = i * distribution;


            foreach (var emp in setOfEmployee)
            {
                emp.Grade = grades[i-1].Name;
                emp.GradeRank = grades[i-1].Rank;
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