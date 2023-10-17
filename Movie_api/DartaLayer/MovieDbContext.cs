using Microsoft.EntityFrameworkCore;
using Movie_api.Model;
using System.Collections.Generic;

namespace Movie_api.DartaLayer
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options) { }
        public DbSet<Moveis> Moveiss { get; set; }
        public DbSet<Author> Authors { get; set; }



    }
}