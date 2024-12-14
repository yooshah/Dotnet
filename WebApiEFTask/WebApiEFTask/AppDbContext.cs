using Microsoft.EntityFrameworkCore;
using WebApiEFTask.Models;

namespace WebApiEFTask
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasOne(r => r.Course).WithMany(r => r.Students).HasForeignKey(k => k.CourseId);

            //Seed Data

            modelBuilder.Entity<Course>().HasData(
                new Course {CourseId=1,CourseName="DotNet",Teacher="Rinsha" },
                new Course { CourseId=2,CourseName="Node js",Teacher="Haneena"},
                new Course { CourseId=3,CourseName="Python",Teacher="Minhaj"}

                );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id=1,Name="Sample",Age=30,Dob=new DateOnly(2000,12,22),Email="sample@filer.com",Phone=1234567891,Password="123@abc",CourseId=1}
                );

            //modelBuilder.Entity<Student>().Property(x => x.Phone).HasConversion<long>().HasAnnotation("Range", new { Min = 1000000000, Max = 9999999999 });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }


    }


}
