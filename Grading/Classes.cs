
namespace MyConsoleApp;
public class Employee
{
    public string Name { get; set; }
    public double Score { get; set; }
    public string Grade { get; set; }
    public long GradeRank { get; set; } // To sort employees by grade rank
}

public class Grade
{
    public string Name { get; set; }
    public long Rank { get; set; } // Lower Rank = Higher Grade
    public double PercentageToAssign { get; set; } // It has to be double in order to work
}
