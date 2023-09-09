using Employee_Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Book.DbConfig
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options) 
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
