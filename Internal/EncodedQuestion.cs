using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenTDB
{
    internal class EncodedQuestion
    {
        [JsonProperty("category")]
        internal string Category { get; set; }

        [JsonProperty("type")]
        internal string Type { get; set; }

        [JsonProperty("difficulty")]
        internal string Difficulty { get; set; }

        [JsonProperty("question")]
        internal string Question { get; set; }

        [JsonProperty("correct_answer")]
        internal string CorrectAnswer { get; set; }

        [JsonProperty("incorrect_answers")]
        internal List<string> IncorrectAnswers { get; set; }
    }
}