using AccountFunction.Core.Entity;
using AccountFunction.Core.Interfaces.Repository;
using AccountFunction.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Infrastructure.Domain.Repository
{
    public class TransactionRepository :Repository<Transaction>,ITransactionRepository
    {
        protected new readonly DataContext _dataContext;

        public TransactionRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

    }
}
