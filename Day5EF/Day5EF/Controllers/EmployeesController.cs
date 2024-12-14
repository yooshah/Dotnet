using AutoMapper;
using Day5EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day5EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase

    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EmployeesController(AppDbContext appDbContext,IMapper mapper)
        {
            _context = appDbContext;
            _mapper = mapper;

        }
        [HttpGet]

        public IActionResult GetAll()
        {

            var employeesDetail = _context.Employees.ToList();

            var employeeDtos = employeesDetail.Select(i => new EmployeeDTO
            {
                EmployeesId = i.EmployeesId,
                EmployeeName = i.EmployeeName,
                Salary = i.Salary,
                
                dptId = i.dptId
            });

            return Ok(employeeDtos);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeDTO employeeDTO)
        {
            Employees newEmployee = new Employees
            {
                EmployeesId= employeeDTO.EmployeesId,
                    EmployeeName = employeeDTO.EmployeeName,
                    Salary = employeeDTO.Salary,
                    Joindate=employeeDTO.Joindate,
                    dptId=employeeDTO.dptId


            };
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
            return Ok();

        }

        [HttpGet("AutoMaper")]

        public IActionResult GetEvery()
        {
            var employeeDetail = _context.Employees.ToList();
            var employeedto=_mapper.Map<List<EmployeeDTO>>(employeeDetail);

            return Ok(employeedto);
        }
    }
}
