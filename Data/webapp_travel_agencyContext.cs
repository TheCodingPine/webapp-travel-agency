using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data
{
    public class webapp_travel_agencyContext : DbContext
    {
        public DbSet<PacchettoViaggio> PacchettoViaggio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //override di OnCOnfig col nostro database
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=DbTravelAgency;Integrated Security=True"); //settato nome
        }
    }
}
