using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cis174projects.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options)
            : base(options) { }
        public DbSet<Game> Games { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sport>().HasData(
                new Sport { SportID = "Curling", SportName = "Indoor" },
                new Sport { SportID = "Bobsleigh", SportName = "Outdoor" },
                new Sport { SportID = "Diving", SportName = "Indoor" },
                new Sport { SportID = "Road Cycling", SportName = "Outdoor" },
                new Sport { SportID = "Archery", SportName = "Indoor" },
                new Sport { SportID = "Canoe Sprint", SportName = "Outdoor" },
                new Sport { SportID = "Breakdancing", SportName = "Indoor" },
                new Sport { SportID = "Skateboarding", SportName = "Outdoor" }
                );
            modelBuilder.Entity<Game>().HasData(
                new Game { GameID = "Winter", Name = "Winter Olympics" },
                new Game { GameID = "Summer", Name = "Summer Olympics" },
                new Game { GameID = "Paralympics", Name = "Paralympics" },
                new Game { GameID = "Youth", Name = "Youth Olympic Games" }
                );
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryID = "ca", Name = "Canada", GameID = "Winter", SportID = "Curling", LogoImage = "ca.png" },
                new Country { CountryID = "se", Name = "Sweden", GameID = "Winter", SportID = "Curling", LogoImage = "se.png" },
                new Country { CountryID = "gb", Name = "Great Britain", GameID = "Winter", SportID = "Curling", LogoImage = "gb.png" },
                new Country { CountryID = "jm", Name = "Jamaica", GameID = "Winter", SportID = "Bobsleigh", LogoImage = "jm.png" },
                new Country { CountryID = "it", Name = "Italy", GameID = "Winter", SportID = "Bobsleigh", LogoImage = "it.png" },
                new Country { CountryID = "jp", Name = "Japan", GameID = "Winter", SportID = "Bobsleigh", LogoImage = "jp.png" },
                new Country { CountryID = "de", Name = "Germany", GameID = "Summer", SportID = "Diving", LogoImage = "de.png" },
                new Country { CountryID = "cn", Name = "China", GameID = "Summer", SportID = "Diving", LogoImage = "cn.png" },
                new Country { CountryID = "mx", Name = "Mexico", GameID = "Summer", SportID = "Diving", LogoImage = "mx.png" },
                new Country { CountryID = "br", Name = "Brazil", GameID = "Summer", SportID = "Road Cycling", LogoImage = "br.png" },
                new Country { CountryID = "nl", Name = "Netherlands", GameID = "Summer", SportID = "Road Cycling", LogoImage = "nl.png" },
                new Country { CountryID = "us", Name = "USA", GameID = "Summer", SportID = "Road Cycling", LogoImage = "us.png" },
                new Country { CountryID = "th", Name = "Thailand", GameID = "Paralympics", SportID = "Archery", LogoImage = "th.png" },
                new Country { CountryID = "uy", Name = "Uruguay", GameID = "Paralympics", SportID = "Archery", LogoImage = "uy.png" },
                new Country { CountryID = "ua", Name = "Ukraine", GameID = "Paralympics", SportID = "Archery", LogoImage = "ua.png" },
                new Country { CountryID = "at", Name = "Austria", GameID = "Paralympics", SportID = "Canoe Sprint", LogoImage = "at.png" },
                new Country { CountryID = "pk", Name = "Pakistan", GameID = "Paralympics", SportID = "Canoe Sprint", LogoImage = "pk.png" },
                new Country { CountryID = "zw", Name = "Zimbabwe", GameID = "Paralympics", SportID = "Canoe Sprint", LogoImage = "zw.png" },
                new Country { CountryID = "fr", Name = "France", GameID = "Youth", SportID = "Breakdancing", LogoImage = "fr.png" },
                new Country { CountryID = "cy", Name = "Cyprus", GameID = "Youth", SportID = "Breakdancing", LogoImage = "cy.png" },
                new Country { CountryID = "ru", Name = "Russia", GameID = "Youth", SportID = "Breakdancing", LogoImage = "ru.png" },
                new Country { CountryID = "fi", Name = "Finland", GameID = "Youth", SportID = "Skateboarding", LogoImage = "fi.png" },
                new Country { CountryID = "sk", Name = "Slovakia", GameID = "Youth", SportID = "Skateboarding", LogoImage = "sk.png" },
                new Country { CountryID = "pt", Name = "Portugal", GameID = "Youth", SportID = "Skateboarding", LogoImage = "pt.png" }
                );
        }
    }
}