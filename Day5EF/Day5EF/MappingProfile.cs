using AutoMapper;
using Day5EF.Models;
using System.Runtime.CompilerServices;

namespace Day5EF
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employees, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employees>();

            
        }
    }
}
