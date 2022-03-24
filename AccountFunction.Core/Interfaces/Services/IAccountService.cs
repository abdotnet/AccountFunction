using AccountFunction.Core.Models;
using AccountFunction.Core.Models.Contracts.Requests;
using AccountFunction.Core.Models.Contracts.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountFunction.Core.Interfaces.Services
{
    public interface IAccountService
    {
        Task<ApiResponse<WalletResponse>> GetWalletDetailsByAccountId([Required] long accountId);
        Task<ApiResponse<TransactionResponse>> CreateTransaction(TransactionRequest request);
    }
}
