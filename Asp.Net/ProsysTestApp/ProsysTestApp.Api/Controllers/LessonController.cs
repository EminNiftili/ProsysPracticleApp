using Microsoft.AspNetCore.Mvc;
using ProsysTestApp.ApiConfig.Controllers;
using ProsysTestApp.Logic.DataTransferObjects.LessonService;
using ProsysTestApp.Logic.Services;

namespace ProsysTestApp.Api.Controllers
{
    public class LessonController : ApiControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        [HttpGet("lessons")]
        public IActionResult Students()
        {
            var lessons = _lessonService.GetLessons();
            return this.AsSuccessResult(lessons);
        }

        [HttpPost("lesson")]
        public IActionResult Students(LessonDto lesson)
        {
            var errorMessage = _lessonService.RegisterLesson(lesson);
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
