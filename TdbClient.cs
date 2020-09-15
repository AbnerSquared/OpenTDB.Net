using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenTDB
{
    public class TdbClient : IDisposable
    {
        private readonly HttpClient _client;
        // private string _session;

        public TdbClient()
        {
            _client = new HttpClient();
        }

        public async Task<string> RequestSessionTokenAsync()
        {
            var args = new List<string>
            {
                $"command={TokenCommand.Request.ToString().ToLower()}"
            };

            string endpoint = API.CreateQuery(API.TokenEndpoint, args);
            var result = await GetAsync<SessionToken>(endpoint);

            return result?.Token;
        }

        public async Task<bool> ResetSessionTokenAsync(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException(nameof(token), "Expected a value for the specified token");

            var args = new List<string>
            {
                $"command={TokenCommand.Reset.ToString().ToLower()}",
                $"token={token}"
            };

            string endpoint = API.CreateQuery(API.TokenEndpoint, args);
            var result = await GetAsync<ResetResult>(endpoint);

            return result?.ResponseCode == ResponseCode.Success;
        }

        public async Task<TriviaSession> CreateSessionAsync()
        {
            var result = await RequestSessionTokenAsync();

            if (string.IsNullOrWhiteSpace(result))
                throw new Exception("An error has occurred while requesting a new session token.");

            return new TriviaSession(result);
        }


        public async Task<List<TriviaCategory>> GetAllCategoriesAsync()
        {
            var result = await GetAsync<CategoryCollection>(API.CategoryEndpoint);
            return result?.Categories;
        }

        public async Task<CategoryQuestionCount> GetQuestionCountAsync(int categoryId)
        {
            var args = new List<string>
            {
                $"category={categoryId}"
            };
            string endpoint = API.CreateQuery(API.CountEndpoint, args);
            var result = await GetAsync<CategoryCount>(endpoint);

            return result?.Count;
        }

        public async Task<List<TriviaQuestion>> GetQuestionsAsync(TriviaSession session)
        {
            if (DateTime.UtcNow - session.LastRequest >= TimeSpan.FromHours(API.SessionTokenTimeoutHours))
                throw new Exception("The specified session has expired due to inactivity.");

            var questions = await GetQuestionsAsync(session.QuestionCount, session.CategoryId, session.Difficulty, session.Type, session.Token);

            if (questions == null)
                throw new Exception("An error has occurred while attempting to retrieve questions.");

            session.LastRequest = DateTime.UtcNow;
            return questions;
        }

        public async Task<List<TriviaQuestion>> GetQuestionsAsync(int amount = 50, int? categoryId = null,
            Difficulty? difficulty = null, QuestionType? type = null, string token = null)
        {
            amount = amount < 0 ? 0 : amount;

            if (amount == 0)
                return new List<TriviaQuestion>();

            var args = new List<string>
            {
                $"amount={amount}"
            };

            if (categoryId.HasValue)
                args.Add($"category={categoryId.Value}");

            if (difficulty.HasValue) // Check if the specified difficulty is an actual flag
                args.Add($"difficulty={difficulty.Value.ToString().ToLower()}");

            if (type.HasValue)
                args.Add($"type={type.Value.ToString().ToLower()}");

            args.Add($"encode={ResponseEncoding.Base64.ToString().ToLower()}");

            if (!string.IsNullOrWhiteSpace(token))
                args.Add($"token={token}");

            string endpoint = API.CreateQuery(API.BaseEndpoint, args);
            var result = await GetAsync<QuestionResult>(endpoint);

            return result?.Questions.Select(API.DecodeQuestion).ToList();
        }

        protected async Task<T> GetAsync<T>(string endpoint)
        {
            HttpResponseMessage result = await _client.GetAsync($"{API.BaseUrl}{endpoint}");

            return result.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync()) : default;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}