using AccountFunction.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Core.Interfaces.Repository
{
    public interface IWalletRepository :IRepository<Wallet>
    {
        Task<Wallet?> GetByAccountId(long accountId);
    }
}
