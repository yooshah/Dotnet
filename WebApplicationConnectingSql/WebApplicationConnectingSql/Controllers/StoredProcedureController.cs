using WebApplicationConnectingSql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationConnectingSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoredProcedureController : ControllerBase
    {
        private readonly string _connectionString;
        public StoredProcedureController()
        {
            _connectionString = "data source=.; database=EmployeesDetails ; Trusted_Connection=True; MultipleActiveResultSets=true; TrustServerCertificate=true";
        }

        [HttpPost("IncrementSalary")]
        public IActionResult IncSalarySP([FromBody] IncrementSalary inc)
        {

            if (inc.EmpId <= 0 || inc.IncSalary <= 0)
            {
                return BadRequest("Invalid EmpId or IncSalary values.");
            }


            try
            {

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        CommandText = "SalaryInc",
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure

                    };

                    SqlParameter param1 = new SqlParameter
                    {
                        ParameterName = "@EmpId",
                        SqlDbType = SqlDbType.Int,
                        Value = inc.EmpId,
                        Direction = ParameterDirection.Input
                    };
                    cmd.Parameters.Add(param1);

                    SqlParameter param2 = new SqlParameter
                    {
                        ParameterName = "@Incsalary",
                        SqlDbType = SqlDbType.Int,
                        Value = inc.IncSalary,
                        Direction = ParameterDirection.InputOutput
                    };
                    cmd.Parameters.Add(param2);

                    connection.Open();

                    cmd.ExecuteNonQuery();
                    return Ok($"new salary : {param2.Value.ToString()}");

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
