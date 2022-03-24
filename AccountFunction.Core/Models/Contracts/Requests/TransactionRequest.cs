using AccountFunction.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Core.Models.Contracts.Requests
{
    public class TransactionRequest
    {
        public decimal Amount { get; set; }
        public Direction Direction { get; set; }
        public long Account { get; set; }
    }
}
