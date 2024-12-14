using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiEFTask.DTO;
using WebApiEFTask.Models;

namespace WebApiEFTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentController(AppDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetAll()
        {

            var students = _context.Students.ToList();

            var studentsdto = _mapper.Map<List<StudentDto>>(students);

            return Ok(studentsdto);


        }

        [HttpPost]

        public IActionResult AddStudent(AddStudentDto newStudent)
        {

            var newStd = _mapper.Map<Student>(newStudent);
            _context.Students.Add(newStd);
            _context.SaveChanges();
            return Ok("Aadded");
        }

        [HttpDelete]

        public IActionResult DeleteStudent(int id) {


            var delstd = _context.Students.FirstOrDefault(s => s.Id == id);

            if (delstd == null)
            {
                return BadRequest("No id Found");

            }

            _context.Students.Remove(delstd);

            _context.SaveChanges();


            return Ok("Deleted");
        }

        [HttpPut("{id}")]

        public IActionResult EditStudent(AddStudentDto editstudent,int id)
        {
            var edtstd= _context.Students.FirstOrDefault(x=>x.Id==id);

            if (edtstd == null)
            {
                return BadRequest("No id Found");
            }
            edtstd.Name = editstudent.Name;
            edtstd.Email = editstudent.Email;
            edtstd.Phone = editstudent.Phone;
            edtstd.Age = editstudent.Age;
            edtstd.Password = editstudent.Password;

            _context.SaveChanges();

            return Ok("Update");

        }




    }
}
