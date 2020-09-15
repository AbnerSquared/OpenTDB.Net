using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTDB
{
    internal class API
    {
        internal static readonly string BaseUrl = "https://opentdb.com/";
        internal static readonly string BaseEndpoint = "api.php";
        internal static readonly string TokenEndpoint = "api_token.php";
        internal static readonly string CategoryEndpoint = "api_category.php";
        internal static readonly string CountEndpoint = "api_count.php";
        internal static readonly string CountGlobalEndpoint = "api_count_global.php";

        internal static readonly int SessionTokenTimeoutHours = 6;
        internal static readonly int MaxQuestionsPerRequest = 50;

        internal static string CreateQuery(string endpoint, in IEnumerable<string> args)
            => $"{endpoint}{(args?.Any() ?? false ? $"?{string.Join("&", args)}" : "")}";

        internal static string DecodeBase64(string input)
        {
            byte[] rawChars = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(rawChars);
        }

        internal static TriviaQuestion DecodeQuestion(EncodedQuestion question)
        {
            string category = DecodeBase64(question.Category);
            bool parseType = Enum.TryParse(DecodeBase64(question.Type), true, out QuestionType type);
            bool parseDifficulty = Enum.TryParse(DecodeBase64(question.Difficulty), true, out Difficulty difficulty);
            string questionText = DecodeBase64(question.Question);
            string answer = DecodeBase64(question.CorrectAnswer);
            List<string> incorrect = question.IncorrectAnswers.Select(DecodeBase64).ToList();

            if (!parseType || !parseDifficulty)
                return null;

            return new TriviaQuestion(category, type, difficulty, questionText, answer, incorrect);
        }
    }
}