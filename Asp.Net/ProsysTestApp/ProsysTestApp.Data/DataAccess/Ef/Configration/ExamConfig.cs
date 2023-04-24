using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProsysTestApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProsysTestApp.Data.DataAccess.Ef.Configration
{
    public class ExamConfig : BaseConfig<ExamEntity>
    {
        public override void Configure(EntityTypeBuilder<ExamEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Exam");
            builder.HasKey(x => new { x.LessonCode, x.StudentNumber });
        }
    }
}
