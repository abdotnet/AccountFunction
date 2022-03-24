using AccountFunction.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Infrastructure.Data
{
    public class Seed
    {
        public static void CreateSeedData(DataContext context)
        {

            if (!context.Wallets.Any())
            {
                context.Wallets.Add(new Wallet()
                {
                    AccountId = 1001,
                    Amount = 10000000,
                    CreatedDate = DateTime.Now,
                });
                context.SaveChanges();
            }

        }
    }
}
