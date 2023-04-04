using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankWebApp.Models;

namespace BankWebApp.Data
{
    public class BankWebAppContext : DbContext
    {
        public BankWebAppContext (DbContextOptions<BankWebAppContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Account { get; set; } = default!;
        public DbSet<TransactionRecord> TransactionRecord { get; set; } = default!;
    }
}
