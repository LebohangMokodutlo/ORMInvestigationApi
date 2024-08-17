using Microsoft.EntityFrameworkCore;
using MyDotNetApi.Models;

namespace MyDotNetApi.Data
{
    public class DataContextEF : DbContext
    {
        public DataContextEF(DbContextOptions<DataContextEF> options) : base(options)
        {
        }

        public DbSet<Users> UsersTable { get; set; }
        public DbSet<UserJobInfo> UserJobInfoTable { get; set; }
        public DbSet<UserSalary> UserSalaryTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Users>()
                .HasKey(u => u.userId);
            modelBuilder.Entity<UserJobInfo>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<UserSalary>()
                .HasKey(u => u.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
