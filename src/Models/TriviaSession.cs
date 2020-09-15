using System;

namespace OpenTDB
{
    public class TriviaSession
    {
        internal TriviaSession(string token)
        {
            Token = token;
            LastRequest = DateTime.UtcNow;
        }

        internal string Token { get; }

        internal DateTime LastRequest { get; set; }

        public int QuestionCount { get; set; }

        public int? CategoryId { get; set; }

        public Difficulty? Difficulty { get; set; }

        public QuestionType? Type { get; set; }

        // If the session should reset the token when all questions are exhausted
        public bool AutoRefresh { get; set; }

    }
}