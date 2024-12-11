using Microsoft.EntityFrameworkCore;

namespace Hairdresser.Models
{
    public class DbContext1 : DbContext
    {
        public DbSet<Employee> Employees { get; set;}

        public DbSet<Customer> Customers { get; set;}
        
        public DbSet<Appointment> Appointments { get; set;}

        public DbSet<Service> Services { get; set;}

        public DbSet<WorkingHours> WorkingHours { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HairDresserDb;Trusted_Connection=True;");
        }
    }
}


