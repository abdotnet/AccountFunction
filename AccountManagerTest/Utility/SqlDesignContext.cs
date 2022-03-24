using AccountFunction.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Utility
{
    public class SqlDesignContext : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            string conString = Environment.GetEnvironmentVariable("DefaultSqlConnection", EnvironmentVariableTarget.User);
            Debug.WriteLine("Checking con string :" + conString);

            optionsBuilder.UseSqlServer(conString);

            return new DataContext(optionsBuilder.Options);
        }

    }
}
