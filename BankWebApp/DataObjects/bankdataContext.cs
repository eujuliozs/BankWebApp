using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BankWebApp.Models;
using BankWebApp.Models.Enums;

namespace BankWebApp.DataObjects
{
    public partial class bankdataContext : DbContext
    {
        public bankdataContext()
        {
        }

        public bankdataContext(DbContextOptions<bankdataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=10032005Jc%;database=bankdata", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Account>? Account { get; set; } = default!;
        public DbSet<TransactionRecord>? TransactionRecords { get; set; } = default!;
        public DbSet<TransactionType>? TransactionTypes { get; set; } = default!;
    }
}
