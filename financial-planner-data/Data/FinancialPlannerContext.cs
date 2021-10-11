using System;
using FinancialPlanner.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialPlanner.Data.Data
{
    public class FinancialPlannerContext : DbContext
    {
        public FinancialPlannerContext(DbContextOptions<FinancialPlannerContext> options) : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<UserBalance> UserBalances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>().ToTable("Bill");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Frequency>().ToTable("Frequency");
            modelBuilder.Entity<UserBalance>().ToTable("UserBalance");
        }
    }
}