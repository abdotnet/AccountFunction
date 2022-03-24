using AccountFunction.Core.Models.Contracts.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Infrastructure.Validators
{
    public class TransactionRequestValidator : AbstractValidator<TransactionRequest>
    {
        public TransactionRequestValidator()
        {
            RuleFor(t => t.Amount).GreaterThan(0);
            RuleFor(t => t.Account).NotEmpty().NotNull();
            RuleFor(t => t.Direction).NotNull();
        }
    }
}
