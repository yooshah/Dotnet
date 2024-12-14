namespace Day5EF.Models
{
    public class Employees
    {
     
        public int EmployeesId { get; set; }

        public string EmployeeName { get; set; }

        public int Salary { get; set; } 

        public DateOnly Joindate { get; set; }

        public int dptId { get; set; }

        public Department department { get; set; }

    }
}
