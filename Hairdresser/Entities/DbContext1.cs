using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Hairdresser.Models;

namespace Hairdresser.Entities
{
    public class DbContext1 : DbContext
    {
        public DbContext1(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Calisan> Calisan { get; set; }
        public DbSet<Servis> Services  { get; set; }
        public DbSet<Randevu> Appointments { get; set; }

    }
}


