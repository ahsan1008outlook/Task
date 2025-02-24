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
        for (int i = 0; i < totalGrades; i++)
        {
            if(grades[i].PercentageToAssign == 0) continue;

            double percentage = 1.0 / grades[i].PercentageToAssign;
            double distribution = totalEmployees * percentage;

            int difference =   (int)Math.Round(lastSkip);
            if(difference > lastSkip)
            {
                distribution += difference - lastSkip;
                lastSkip = difference;
            } 
            // else if(difference < lastSkip) {
            //     distribution += lastSkip - difference;
            //     lastSkip = difference;
            // }

            int toTaken = (int)Math.Round(distribution);
            int toSkip = (int)Math.Round(lastSkip);


            // if(toTaken >= 1)
            // {
                var setOfEmployee = employees.Skip(toSkip).Take(toTaken);
                Console.WriteLine("Take {0} Skip {1} LastSkip {2} Per% {3} Dist {4}", toTaken, toSkip, lastSkip, percentage, distribution );

                foreach (var emp in setOfEmployee)
                {
                    emp.Grade = grades[i].Name;
                    emp.GradeRank = grades[i].Rank;
                }
                employeesNew.AddRange(setOfEmployee);
            // }
            


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