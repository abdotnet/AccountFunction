using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Core.Models.Contracts.Response
{
    public class TransactionResponse
    {
        public decimal Amount { get; set; }
        public long AccountId { get; set; }
    }
}
