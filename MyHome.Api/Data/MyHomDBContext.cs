using Microsoft.EntityFrameworkCore;
using MyHome.Api.Models;
using System;

namespace MyHome.Api.Data
{
    public class MyHomDBContext : DbContext
    {
        public MyHomDBContext(DbContextOptions<MyHomDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=MyHomeDatabase.db");
            }
        }
    }
}
