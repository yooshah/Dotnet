using AutoMapper;
using WebApiEFTask.DTO;
using WebApiEFTask.Models;

namespace WebApiEFTask
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<AddStudentDto,Student>();
            CreateMap<Student, AddStudentDto>();
        }
    }
}
