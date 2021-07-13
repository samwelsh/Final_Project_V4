using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final_Project.Models;

namespace Final_Project.Data
{
    public class Final_ProjectContext : DbContext
    {
        public Final_ProjectContext (DbContextOptions<Final_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Final_Project.Models.Agent> Agent { get; set; }

        public DbSet<Final_Project.Models.City> City { get; set; }

        public DbSet<Final_Project.Models.Dwelling> Dwelling { get; set; }

        public DbSet<Final_Project.Models.SalesOffice> SalesOffice { get; set; }
    }
}
