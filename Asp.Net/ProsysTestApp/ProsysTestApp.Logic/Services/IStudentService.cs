using ProsysTestApp.Logic.DataTransferObjects.StudentService;

namespace ProsysTestApp.Logic.Services
{
    public interface IStudentService
    {
        string RegisterStudent(StudentDto student);
        List<StudentDto> GetStudents();
    }
}
