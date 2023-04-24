using ProsysTestApp.Core.AutoMapper;
using ProsysTestApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsysTestApp.Logic.DataTransferObjects.StudentService
{
    public class StudentDto : IBidirectionalMap<StudentEntity>
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Class { get; set; }
    }
}
