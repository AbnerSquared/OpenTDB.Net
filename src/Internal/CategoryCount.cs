using Newtonsoft.Json;

namespace OpenTDB
{
    internal class CategoryCount
    {
        [JsonProperty("category_id")]
        internal int CategoryId { get; set; }

        [JsonProperty("category_question_count")]
        internal CategoryQuestionCount Count { get; set; }
    }
}