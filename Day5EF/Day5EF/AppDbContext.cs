using Day5EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Day5EF
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet <Employees> Employees { get; set; }

        public DbSet<Department> departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>().HasOne(r => r.department).WithMany(r => r.Employees).HasForeignKey(r=>r.dptId).OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Department>().HasData(
                new Department { dptId = 4, dptName = "IT" },
                new Department { dptId = 5, dptName = "HR" }
            );

            // Seed data for employees
            modelBuilder.Entity<Employees>().HasData(
                new Employees { EmployeesId = 1, EmployeeName = "Suhail", Salary = 500, Joindate = new DateOnly(2023, 1, 1), dptId = 1 },
                new Employees { EmployeesId = 2, EmployeeName = "John", Salary = 700, Joindate = new DateOnly(2023, 2, 1), dptId = 2 }
            );
        }
        

    }
}
