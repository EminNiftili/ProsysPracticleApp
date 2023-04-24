using Microsoft.AspNetCore.Mvc;
using ProsysTestApp.ApiConfig.Controllers;
using ProsysTestApp.Logic.DataTransferObjects.StudentService;
using ProsysTestApp.Logic.Services;

namespace ProsysTestApp.Api.Controllers
{
    public class StudentController : ApiControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("students")]
        public IActionResult Students()
        {
            var students = _studentService.GetStudents();
            return this.AsSuccessResult(students);
        }

        [HttpPost("student")]
        public IActionResult Students(StudentDto student)
        {
            var errorMessage = _studentService.RegisterStudent(student);
            if (string.IsNullOrEmpty(errorMessage))
            {
                return this.AsSuccessResult("ok");
            }
            else
            {
                return this.AsBadResult(errorMessage);
            }
        }
    }
}
