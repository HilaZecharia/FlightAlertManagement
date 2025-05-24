using FlightAlertManagment.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace FlightAlertManagment.Data
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Alert> Alerts { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Alert>()
                    .OwnsOne(a => a.FlightData);
            }
    }

}
