using DrawData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawData.Context
{
    public class MasterContext : DbContext
    {
        public MasterContext()
        {
        }
        public MasterContext(DbContextOptions option) : base(option)
        {
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<UserDepartmanModel> UserDepartman { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDepartmanModel>()
                .HasMany(p => p.User)
                .WithOne(s => s.UserDepartman)
                .HasForeignKey(k => k.UserDepartmanId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseMySQL(Environment.GetEnvironmentVariable("MYSQL_URI"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
