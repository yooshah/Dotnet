using System.ComponentModel.DataAnnotations;

namespace WebApiEFTask.DTO
{
    public class AddStudentDto
    {

        [Key]
        public int Id { get; set; }
        [Required]

        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public DateOnly Dob { get; set; }

        public string Email { get; set; }

        [Range(1000000000, 9999999999, ErrorMessage = "Phone number must be exactly 10 digits.")]
        public long Phone { get; set; }

        public string Password { get; set; }

        public int CourseId { get; set; }
    }
}
