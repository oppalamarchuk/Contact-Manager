namespace Contact_Manager.Models;

public class Employee
{
    public int Id { get; set; }
    public DateTime BirthDate { get; set; }

    public bool Married { get; set; }

    public string Name { get; set; } = null!;
    
    public string Phone { get; set; } = null!;
    
    public decimal Salary { get; set; }
}