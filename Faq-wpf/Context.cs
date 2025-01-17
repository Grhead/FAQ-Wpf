﻿using Faq_wpf.Models;
using Microsoft.EntityFrameworkCore;

namespace Faq_wpf
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.EnsureCreated();
        }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.TaskX> TaskXes { get; set; }
        public DbSet<Models.Status> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FAQdb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskX>()
                .HasOne(x => x.UsersSet)
                .WithMany(x => x.TaskXesSet)
                .HasForeignKey(x => x.UsersSetId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);


            modelBuilder.Entity<TaskX>()
                .HasOne(x => x.UsersGet)
                .WithMany(x => x.TaskXesGet)
                .HasForeignKey(x => x.UsersGetId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            base.OnModelCreating(modelBuilder);
        }

    }
}
