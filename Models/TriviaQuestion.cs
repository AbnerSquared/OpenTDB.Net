using System.Collections.Generic;

namespace OpenTDB
{
    public class TriviaQuestion
    {
        internal TriviaQuestion(string category, QuestionType type, Difficulty difficulty,
            string question, string answer, List<string> incorrectAnswers)
        {
            Category = category;
            Type = type;
            Difficulty = difficulty;
            Question = question;
            Answer = answer;
            IncorrectAnswers = incorrectAnswers;
        }

        public string Category { get; }

        public QuestionType Type { get; }

        public Difficulty Difficulty { get; }

        public string Question { get; }

        public string Answer { get; }

        public List<string> IncorrectAnswers { get; }
    }
}