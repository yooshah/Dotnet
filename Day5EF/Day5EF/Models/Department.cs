using System.ComponentModel.DataAnnotations;

namespace Day5EF.Models
{
    public class Department
    {
        [Key]
        public int dptId { get; set; }

        public string dptName { get; set; }

       

        public ICollection<Employees> Employees { get; set; }
    }
}
