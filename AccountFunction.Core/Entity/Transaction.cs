using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Core.Entity
{
    public class Transaction
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public Direction Direction { get; set; }
        public long Account { get; set; }
    }

    public enum Direction
    {
        Debit = 1
    }
}
