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
    public class StudentConfig : BaseConfig<StudentEntity>
    {
        public override void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Student");
            builder.HasKey(x => x.Number);
        }
    }
}
