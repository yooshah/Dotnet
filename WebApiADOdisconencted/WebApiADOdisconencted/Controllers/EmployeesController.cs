using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApiADOdisconencted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly string _connection;
        public EmployeesController(IConfiguration configuration) {

            _connection = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connection))
                {

                    string query1 = "SELECT * FROM Employee";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query1, connection);

                    DataSet dataSet = new DataSet();

                    dataAdapter.Fill(dataSet, "EmployeeTable");

                    DataTable dataTable = dataSet.Tables["EmployeeTable"];



                    foreach(DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine($"Name{row[1]} salary-{row[3]}");
                    }
                    return Ok("Complted");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:"+ex.Message);
                return BadRequest(ex.Message);

            }


        }
    }
}
