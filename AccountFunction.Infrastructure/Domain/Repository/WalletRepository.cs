using AccountFunction.Core.Entity;
using AccountFunction.Core.Interfaces.Repository;
using AccountFunction.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Infrastructure.Domain.Repository
{
    public class WalletRepository : Repository<Wallet>, IWalletRepository
    {
        protected new readonly DataContext _dataContext;

        public WalletRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Wallet?> GetByAccountId(long accountId)
        {
            var query = await _dataContext.Wallets.Where(c => c.AccountId == accountId)
                .FirstOrDefaultAsync();

            return query ?? null;
        }
    }
}
