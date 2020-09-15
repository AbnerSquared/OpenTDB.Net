using Newtonsoft.Json;

namespace OpenTDB
{
    public class CategoryQuestionCount
    {
        [JsonProperty("total_question_count")]
        public int Total { get; internal set; }

        [JsonProperty("total_easy_question_count")]
        public int Easy { get; internal set; }

        [JsonProperty("total_medium_question_count")]
        public int Medium { get; internal set; }

        [JsonProperty("total_hard_question_count")]
        public int Hard { get; internal set; }
    }
}