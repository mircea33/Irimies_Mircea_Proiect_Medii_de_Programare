using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Irimies_Mircea_Proiect_Medii_de_Programare.Models;

namespace Irimies_Mircea_Proiect_Medii_de_Programare.Data
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options) :
base(options)
        {
        }
        public DbSet<Jucator> Jucators { get; set; }
        public DbSet<Antrenor> Antrenors { get; set; }
        public DbSet<Echipa> Echipas { get; set; }
        public DbSet<Conferinta> Conferintas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jucator>().ToTable("Jucator");
            modelBuilder.Entity<Antrenor>().ToTable("Antrenor");
            modelBuilder.Entity<Echipa>().ToTable("Echipa");
            modelBuilder.Entity<Conferinta>().ToTable("Conferinta");
        }
    }
}