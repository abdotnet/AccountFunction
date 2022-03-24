using AccountFunction.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;

namespace AccountFunction.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WalletConfiguration).Assembly);

            // set minimum transaction amount to 1000
            modelBuilder.Entity<Wallet>().HasQueryFilter(w => w.Amount > 1000);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conString = Environment.GetEnvironmentVariable("DefaultSqlConnection", EnvironmentVariableTarget.User) ?? "";

                optionsBuilder.UseSqlServer(conString);
            }
        }
    }
}

