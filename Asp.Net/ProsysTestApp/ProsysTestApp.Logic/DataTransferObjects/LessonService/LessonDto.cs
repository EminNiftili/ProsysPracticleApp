using ProsysTestApp.Core.AutoMapper;
using ProsysTestApp.Data.Entities;

namespace ProsysTestApp.Logic.DataTransferObjects.LessonService
{
    public class LessonDto : IBidirectionalMap<LessonEntity>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
    }
}
