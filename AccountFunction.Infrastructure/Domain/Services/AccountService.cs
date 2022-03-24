using AccountFunction.Core.Entity;
using AccountFunction.Core.Interfaces;
using AccountFunction.Core.Interfaces.Services;
using AccountFunction.Core.Models;
using AccountFunction.Core.Models.Contracts.Requests;
using AccountFunction.Core.Models.Contracts.Response;
using AccountFunction.Core.Utility;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace AccountFunction.Infrastructure.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountService> _logger;
        public AccountService(IUnitOfWork unitOfWork, ILogger<AccountService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }

        public async Task<ApiResponse<WalletResponse>> GetWalletDetailsByAccountId([Required] long accountId)
        {
            var query = await _unitOfWork.Wallet.GetByAccountId(accountId);

            return query != null ? ApiResponse<WalletResponse>.GetApiResult(new WalletResponse()
            {
                AccountId = query.AccountId,
                Amount = query.Amount,
                CreatedDate = query.CreatedDate,
            }, Constants.ResponseCodes.Success, Constants.ResponseMessage.Success) :
            ApiResponse<WalletResponse>.GetApiResult(null, Constants.ResponseCodes.NotFound, Constants.ResponseMessage.NotFound);
        }

        public async Task<ApiResponse<TransactionResponse>> CreateTransaction(TransactionRequest request)
        {

            // deplete the wallet
            try
            {
                Wallet? userWallet = await _unitOfWork.Wallet.GetByAccountId(request.Account);

                if (userWallet == null)
                    return ApiResponse<TransactionResponse>.GetApiResult(null, Constants.ResponseCodes.NotFound, "Wallet not found");

                if (request.Amount > userWallet.Amount)
                    return ApiResponse<TransactionResponse>.GetApiResult(null, Constants.ResponseCodes.Failed, "Requested amount is greater than the balance");

                userWallet.Amount -= request.Amount;
                _unitOfWork.Wallet.Update(userWallet);
                await _unitOfWork.CompleteAsync();
                // create a new transaction

                Transaction? trans = new()
                {
                    Account = request.Account,
                    Amount = request.Amount,
                    Direction = request.Direction
                };
                _unitOfWork.Transaction.Add(trans);
                await _unitOfWork.CompleteAsync();
                return trans.Id > 0 ? ApiResponse<TransactionResponse>.GetApiResult(new TransactionResponse()
                {
                    AccountId = trans.Account,
                    Amount = trans.Amount
                }, Constants.ResponseCodes.Success, Constants.ResponseMessage.Success) :
          ApiResponse<TransactionResponse>.GetApiResult(null, Constants.ResponseCodes.NotFound, Constants.ResponseMessage.NotFound);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return ApiResponse<TransactionResponse>.GetApiResult(null, Constants.ResponseCodes.NotFound, Constants.ResponseMessage.NotFound);

            }



        }

    }
}
