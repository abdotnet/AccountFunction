using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AccountFunction.Core.Interfaces.Services;
using AccountFunction.Core.Models;
using AccountFunction.Core.Models.Contracts.Requests;
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
    public class CreateAccountFunction
    {
        private readonly ILogger<CreateAccountFunction> _logger;
        private readonly IAccountService _accountService;
        public CreateAccountFunction(ILogger<CreateAccountFunction> log, IAccountService accountService)
        {
            _logger = log;
            _accountService = accountService;

        }

        [FunctionName("createAccount")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(TransactionRequest), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ApiResponse<TransactionResponse>), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "account")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var transRequest = JsonConvert.DeserializeObject<TransactionRequest>(requestBody);

                var response = await _accountService.CreateTransaction(transRequest);

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error : " + ex.Message);
            }

            return new OkObjectResult(ApiResponse<TransactionResponse>.
                GetApiResult(null, Constants.ResponseCodes.BadRequest,
               Constants.ResponseMessage.BadRequest));

        }
    }
}

