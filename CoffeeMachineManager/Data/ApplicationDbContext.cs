﻿using CoffeeMachineManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMachineManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Map models to database tables
        public DbSet<User> Users { get; set; }
        public DbSet<CoffeeMachine> CoffeeMachines { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ConsumptionLog> ConsumptionLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=CoffeeMachineManager;ConnectRetryCount=0");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure unique emails in the Users table
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Feedback -> CoffeeMachine relationship
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.CoffeeMachine)
                .WithMany()
                .HasForeignKey(f => f.CoffeeMachineId)
                .OnDelete(DeleteBehavior.Cascade);

            // ConsumptionLog -> CoffeeMachine relationship
            modelBuilder.Entity<ConsumptionLog>()
                .HasOne(c => c.CoffeeMachine)
                .WithMany()
                .HasForeignKey(c => c.CoffeeMachineId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
