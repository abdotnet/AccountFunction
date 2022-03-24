using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AccountFunction.Core.Interfaces.Services;
using AccountFunction.Core.Models;
using AccountFunction.Core.Models.Contracts.Response;
using AccountFunction.Core.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace AccountFunction.Functions
{
    public class GetAccountFunction
    {
        private readonly ILogger<GetAccountFunction> _logger;
        private readonly IAccountService _accountService;

        public GetAccountFunction(ILogger<GetAccountFunction> log, IAccountService accountService)
        {
            _logger = log;
            _accountService = accountService;
        }

        [FunctionName("getAccountById")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ApiResponse<WalletResponse>), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "account")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                string accountId = req.Query["accountId"];

                if (string.IsNullOrEmpty(accountId))
                    return new OkObjectResult(ApiResponse<WalletResponse>.GetApiResult(null, Constants.ResponseCodes.BadRequest, Constants.ResponseMessage.BadRequest));

                var response = await _accountService.GetWalletDetailsByAccountId(long.Parse(accountId));

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error: " + ex.Message);
            }
            return new OkObjectResult(ApiResponse<WalletResponse>.GetApiResult(null, Constants.ResponseCodes.BadRequest, Constants.ResponseMessage.BadRequest));


        }
    }
}

