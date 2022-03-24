using AccountFunction.Core.Interfaces;
using AccountFunction.Core.Interfaces.Repository;
using AccountFunction.Core.Interfaces.Services;
using AccountFunction.Infrastructure.Data;
using AccountFunction.Infrastructure.Domain;
using AccountFunction.Infrastructure.Domain.Repository;
using AccountFunction.Infrastructure.Domain.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(AccountFunction.Utility.StartUp))]
namespace AccountFunction.Utility
{
  
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("DefaultSqlConnection", EnvironmentVariableTarget.User);
            builder.Services.AddDbContext<DataContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));

            builder.Services.AddTransient<IWalletRepository, WalletRepository>();
            builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            string conString = Environment.GetEnvironmentVariable("DefaultSqlConnection", EnvironmentVariableTarget.User);
           // optionsBuilder.UseSqlServer(conString);

            Seed.CreateSeedData(new DataContext(optionsBuilder.Options));
        }
    }
}
