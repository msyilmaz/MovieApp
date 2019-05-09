using Microsoft.EntityFrameworkCore;
using MovieApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Concrete.EntityFramework
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB;Database=MovieApp;Trusted_Connection=True;MultipleActiveResultSets=true;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
