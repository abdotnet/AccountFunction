using AccountFunction.Core.Interfaces;
using AccountFunction.Core.Interfaces.Repository;
using AccountFunction.Infrastructure.Data;
using AccountFunction.Infrastructure.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IWalletRepository Wallet { get; private set; }
        public ITransactionRepository Transaction { get; private set; }
        public UnitOfWork(DataContext context)
        {
            _context = context;
            Wallet = new WalletRepository(_context);
            Transaction = new TransactionRepository(_context);
        }

        /// <summary>
        /// Complete to db
        /// </summary>
        /// <returns></returns>
        public async Task<long> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Dispose 
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
