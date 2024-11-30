using CleanStudentManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Users> users { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<QnAs> QnAs { get; set; }
        public DbSet<Exams> Exams { get; set; }
        public DbSet<ExamResults> ExamResults { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1,
                    Name = "Admin",
                    Password = "admin",
                    Role=1,
                    UserName = "admin"
                }
            );
            base.OnModelCreating(modelBuilder);
        }

    }
}
