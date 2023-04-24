using Microsoft.AspNetCore.Mvc;
using ProsysTestApp.ApiConfig.Controllers;
using ProsysTestApp.Logic.DataTransferObjects.ExamService;
using ProsysTestApp.Logic.DataTransferObjects.StudentService;
using ProsysTestApp.Logic.Services;

namespace ProsysTestApp.Api.Controllers
{
    public class ExamController : ApiControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }
        [HttpGet("exams")]
        public IActionResult Exam()
        {
            var exams = _examService.GetExams();
            return this.AsSuccessResult(exams);
        }

        [HttpPost("exam")]
        public IActionResult Exam(ExamDto exam)
        {
            var errorMessage = _examService.RegisterExam(exam);
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
