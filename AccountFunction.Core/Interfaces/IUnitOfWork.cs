using AccountFunction.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Core.Interfaces
{
    public interface IUnitOfWork
    {
         IWalletRepository Wallet { get; }
         ITransactionRepository Transaction { get; }
        Task<long> CompleteAsync();
    }
}
