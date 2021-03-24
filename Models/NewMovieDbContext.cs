using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_3.Models
{
    public class NewMovieDbContext : DbContext
    {
        public NewMovieDbContext (DbContextOptions<NewMovieDbContext> options) : base (options)
        {

        }

        public DbSet<NewMovie> NewMovie { get; set; }
    }
}
