using FlightAlertManagment.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace FlightAlertManagment.Data
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<Alert> Alerts { get; set; }
  
        }
}
