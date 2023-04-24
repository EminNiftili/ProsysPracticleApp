using AutoMapper;
using ProsysTestApp.Core.Resources;
using ProsysTestApp.Data.DataAccess;
using ProsysTestApp.Data.Entities;
using ProsysTestApp.Logic.DataTransferObjects.StudentService;

namespace ProsysTestApp.Logic.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<StudentDto> GetStudents()
        {
            var studentEntities = _unitOfWork
                .GetRepository<StudentEntity>()
                .Gets()
                .ToList();

            var students = _mapper.Map<List<StudentDto>>(studentEntities);
            return students;
        }

        public string RegisterStudent(StudentDto student)
        {
            if(student == null)
            {
                return GeneralExceptionMessage.StudentNull;
            }

            var hasDatabase = _unitOfWork
                .GetRepository<StudentEntity>()
                .GetFirstOrDefault(x => x.Number == student.Number) != null;
            if (hasDatabase)
            {
                return GeneralExceptionMessage.DatabaseHasSameStudent;
            }

            var studentEntity = _mapper.Map<StudentEntity>(student);

            _unitOfWork.GetRepository<StudentEntity>().Add(studentEntity);
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
