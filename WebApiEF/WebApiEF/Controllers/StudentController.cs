using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiEF.Models;

namespace WebApiEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public StudentController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        [HttpGet]

        public ActionResult<IEnumerable<Student>> GetAllStudent()
        {
            return _appDbContext.Students.ToList();
        }

        [HttpPost]
       public IActionResult AddStudent(Student student)
        {

            _appDbContext.Students.Add(student);
            _appDbContext.SaveChanges();
            return Ok("Addded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var studentDel = _appDbContext.Students.Find(id);
            if (studentDel == null)
            {
                return NotFound("no Id");


            }

            _appDbContext.Students.Remove(studentDel);

            _appDbContext.SaveChanges();
            return Ok("Deleted");
        }

        [HttpPut("{id}")]

        public IActionResult Updatestudent(Student student,int id)
        {
            var updateStudent = _appDbContext.Students.Find(id);

            if (updateStudent == null)
            {

                return NotFound("not Found");
            }


            updateStudent.StudentName = student.StudentName;
            updateStudent.StudentEmail = student.StudentEmail;
            updateStudent.StudentPhone= student.StudentPhone;
            _appDbContext.SaveChanges();


            return Ok(updateStudent);

        }


    }
}
