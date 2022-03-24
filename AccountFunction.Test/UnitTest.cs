using AccountFunction.Core.Interfaces.Services;
using AccountFunction.Core.Models;
using AccountFunction.Core.Models.Contracts.Requests;
using AccountFunction.Core.Models.Contracts.Response;
using System.Net.Http;
using System.Text.Json;
using Xunit;

namespace AccountFunction.Test
{
    public class UnitTest
    {
        private readonly HttpClient _client;
        public UnitTest(IAccountService accountService)
        {
            _client = new HttpClient
            {
                BaseAddress = new System.Uri(@"http://localhost:7071/api")
            };
        }

        [Fact]
        public async void CanEnterAccountId_Should_GetAccountDetails()
        {
            var response_Success = await _client.GetAsync(@"/account?accountId=1001");
            Assert.True(response_Success.IsSuccessStatusCode);

            var response_Failed_AccountIdInCorrect = await _client.GetAsync(@"/account?accountId=1002");
            Assert.True(!response_Failed_AccountIdInCorrect.IsSuccessStatusCode);

            var response_Failed_AccountIdNotFound = await _client.GetAsync(@"/account");
            Assert.True(!response_Failed_AccountIdNotFound.IsSuccessStatusCode);

            var response_NotEmpty = await response_Success.Content.ReadAsStringAsync();
            Assert.NotEmpty(response_NotEmpty);

            var result = JsonSerializer.Deserialize<ApiResponse<WalletResponse>>(response_NotEmpty);

            Assert.NotNull(result);
            Assert.NotNull(result?.Data);

        }

        [Fact]
        public async void CanEnterRequestPayload_Should_ProcessRequestAndGetResponse()
        {
            var response_Success = await _client.PostAsync(@"/account", new StringContent(JsonSerializer.Serialize(new TransactionRequest()
            {
                Account = 1001,
                Amount = 100,
                Direction = Core.Entity.Direction.Debit
            })));
            Assert.True(response_Success.IsSuccessStatusCode);

            var response_NotEmpty = await response_Success.Content.ReadAsStringAsync();
            Assert.NotEmpty(response_NotEmpty);

            var result = JsonSerializer.Deserialize<ApiResponse<TransactionResponse>>(response_NotEmpty);

            Assert.NotNull(result);
            Assert.NotNull(result?.Data);

        }
    }
}