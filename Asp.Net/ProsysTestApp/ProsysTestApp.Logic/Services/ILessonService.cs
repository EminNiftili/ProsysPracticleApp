using ProsysTestApp.Logic.DataTransferObjects.LessonService;
using ProsysTestApp.Logic.DataTransferObjects.StudentService;

namespace ProsysTestApp.Logic.Services
{
    public interface ILessonService
    {
        string RegisterLesson(LessonDto lesson);
        List<LessonDto> GetLessons();
    }
}
