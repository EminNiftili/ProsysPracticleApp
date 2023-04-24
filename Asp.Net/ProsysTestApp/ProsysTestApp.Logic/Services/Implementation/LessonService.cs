using AutoMapper;
using ProsysTestApp.Core.Resources;
using ProsysTestApp.Data.DataAccess;
using ProsysTestApp.Data.Entities;
using ProsysTestApp.Logic.DataTransferObjects.LessonService;
using ProsysTestApp.Logic.DataTransferObjects.StudentService;

namespace ProsysTestApp.Logic.Services.Implementation
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LessonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<LessonDto> GetLessons()
        {
            var lessonEntities = _unitOfWork
                .GetRepository<LessonEntity>()
                .Gets()
                .ToList();

            var lessons = _mapper.Map<List<LessonDto>>(lessonEntities);
            return lessons;
        }

        public string RegisterLesson(LessonDto lesson)
        {
            if (lesson == null)
            {
                return GeneralExceptionMessage.LessonNull;
            }
            var hasDatabase = _unitOfWork
                .GetRepository<LessonEntity>()
                .GetFirstOrDefault(x => x.Code == lesson.Code) != null;
            if (hasDatabase)
            {
                return GeneralExceptionMessage.DatabaseHasSameLesson;
            }

            var lessonEntity = _mapper.Map<LessonEntity>(lesson);

            _unitOfWork.GetRepository<LessonEntity>().Add(lessonEntity);
            try
            {
                _unitOfWork.Commit();
            }
            catch
            {
                return GeneralExceptionMessage.SomethingWrong;
            }

            return null;
        }
    }
}
