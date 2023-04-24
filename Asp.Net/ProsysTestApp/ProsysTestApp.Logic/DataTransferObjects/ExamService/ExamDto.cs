using ProsysTestApp.Core.AutoMapper;
using ProsysTestApp.Data.Entities;

namespace ProsysTestApp.Logic.DataTransferObjects.ExamService
{
    public class ExamDto : IBidirectionalMap<ExamEntity>
    {
        public string LessonCode { get; set; }
        public int StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public int ExamResult { get; set; }
    }
}
