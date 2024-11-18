using CarDealer.Core.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarDealer.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }

    }
}
