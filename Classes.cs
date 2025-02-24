
namespace MyConsoleApp;
public class Employee
{
    public string Name { get; set; }
    public double Score { get; set; }
    public string Grade { get; set; }
    public int GradeRank { get; set; } // To sort employees by grade rank
}

public class Grade
{
    public string Name { get; set; }
    public int Rank { get; set; } // Lower Rank = Higher Grade
    public int PercentageToAssign { get; set; } 
}
