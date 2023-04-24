using AutoMapper;
using ProsysTestApp.Core.Resources;
using ProsysTestApp.Data.DataAccess;
using ProsysTestApp.Data.Entities;
using ProsysTestApp.Logic.DataTransferObjects.ExamService;
using ProsysTestApp.Logic.DataTransferObjects.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsysTestApp.Logic.Services.Implementation
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<ExamDto> GetExams()
        {
            var examEntities = _unitOfWork
                .GetRepository<ExamEntity>()
                .Gets()
                .ToList();

            var exams = _mapper.Map<List<ExamDto>>(examEntities);
            return exams;
        }

        public string RegisterExam(ExamDto exam)
        {
            if (exam == null)
            {
                return GeneralExceptionMessage.ExamNull;
            }


            var hasDatabase = _unitOfWork
                .GetRepository<ExamEntity>()
                .GetFirstOrDefault(x => x.LessonCode == exam.LessonCode && x.StudentNumber == exam.StudentNumber) != null;
            if (hasDatabase)
            {
                return GeneralExceptionMessage.DatabaseHasSameExam;
            }

            var examEntity = _mapper.Map<ExamEntity>(exam);

            _unitOfWork.GetRepository<ExamEntity>().Add(examEntity);
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
