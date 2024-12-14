using System.ComponentModel.DataAnnotations;

namespace WebApiEF.Models
{
    public class Student
    {

        [Key]
        public int StudentId { get; set; }

        [Required]

        [StringLength(40)]
        public string StudentName { get; set; }

        public string StudentEmail { get; set; }


        public int StudentPhone { get; set; }

        public int Age { get; set; }
    
        //public string name { get; set; }


    }
}
