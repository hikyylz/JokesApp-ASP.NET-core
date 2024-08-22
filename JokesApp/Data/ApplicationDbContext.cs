﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JokesApp.Models;

namespace JokesApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<JokesApp.Models.Joke> Joke { get; set; } = default!;
        public DbSet<JokesApp.Models.BlogPost> BlogPost { get; set; } = default!;
        public DbSet<JokesApp.Models.WeatherForcastModel> WeatherForcastModels { get; set; } = default!;

    }
}
