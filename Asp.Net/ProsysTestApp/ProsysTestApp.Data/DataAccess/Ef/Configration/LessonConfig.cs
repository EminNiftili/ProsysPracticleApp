using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProsysTestApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsysTestApp.Data.DataAccess.Ef.Configration
{
    public class LessonConfig : BaseConfig<LessonEntity>
    {
        public override void Configure(EntityTypeBuilder<LessonEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Lesson");
            builder.HasKey(x => x.Code);
        }
    }
}
