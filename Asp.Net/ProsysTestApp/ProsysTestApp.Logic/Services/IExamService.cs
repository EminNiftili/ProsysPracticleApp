using ProsysTestApp.Logic.DataTransferObjects.ExamService;
using ProsysTestApp.Logic.DataTransferObjects.LessonService;

namespace ProsysTestApp.Logic.Services
{
    public interface IExamService
    {
        string RegisterExam(ExamDto exam);
        List<ExamDto> GetExams();
    }
}
