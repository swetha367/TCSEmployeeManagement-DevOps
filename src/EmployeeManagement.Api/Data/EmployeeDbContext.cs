
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Api.Models;

namespace EmployeeManagement.Api.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(
            DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
