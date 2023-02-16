using Microsoft.EntityFrameworkCore;
using DIO.AzureHRSystem.Models;

namespace DIO.AzureHRSystem.Context
{
    public class HRContext : DbContext
    {

        public HRContext(DbContextOptions<HRContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

    }
}