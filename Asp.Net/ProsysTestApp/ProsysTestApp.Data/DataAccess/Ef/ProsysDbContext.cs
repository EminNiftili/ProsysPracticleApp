using Microsoft.EntityFrameworkCore;
using ProsysTestApp.Core.Settings;
using System.Reflection;

namespace ProsysTestApp.Data.DataAccess.Ef
{
    public class ProsysDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
                .UseSqlServer(AppSettings.Instance.DatabaseSetting.ApiDbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
