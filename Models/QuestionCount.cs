using Newtonsoft.Json;

namespace OpenTDB
{
    public class QuestionCount
    {
        [JsonProperty("total_num_of_questions")]
        public int Total { get; internal set; }

        [JsonProperty("total_num_of_pending_questions")]
        public int Pending { get; internal set; }

        [JsonProperty("total_num_of_verified_questions")]
        public int Verified { get; internal set; }

        [JsonProperty("total_num_of_rejected_questions")]
        public int Rejected { get; internal set; }
    }
}