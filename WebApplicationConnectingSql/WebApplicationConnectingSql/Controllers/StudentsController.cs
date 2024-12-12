using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplicationConnectingSql.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationConnectingSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        
        private readonly string  _connectingString;
        
       
        public StudentsController(IConfiguration configuration) 
        {
            _connectingString = configuration.GetConnectionString("DefaultConnection");

        }

       

        [HttpGet]

        public IActionResult GetAllStudent()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(_connectingString)) 
            {

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT * FROM Students";
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student()
                    {
                        StudentID = (int)reader[0],
                        FirstName = (string)reader[1],
                        LastName = (string)reader[2],
                        Age = (int)reader[3]

                    });
                
                    
                }
                return Ok(students);

            }

        }
        [HttpPost]

        public IActionResult AddStudent([FromBody] Student student)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectingString))
                {
                    string query = "INSERT INTO Students(StudentID,FirstName,LastName,Age)" +
                        "VALUES(@StudentID,@FirstName,@LastName,@Age)";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    connection.Open();

                    int affectedRow = (int)cmd.ExecuteNonQuery();
                    Console.WriteLine(affectedRow);
                    if (affectedRow > 0)
                    {
                        return Ok($"{ affectedRow} inserted successfully");
                    }

                   return  Ok("Non row is added");
                    


                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  

            }

  
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectingString))
            {
                string query = "UPDATE Students " +  
                               "SET FirstName = @FirstName, LastName = @LastName, Age = @Age " + // Added space here too
                               "WHERE StudentID = @StudentID"; 

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StudentID", id);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                connection.Open();

                int affectedRow = (int)cmd.ExecuteNonQuery();
                Console.WriteLine($"id={id} have successfully updated");

                if (affectedRow > 0)
                {
                    return Ok($"Student with id={id} has been successfully updated.");
                }
                else
                {
                    return NotFound($"Student with id={id} not found.");
                }

            }
        }

        
    }
}
