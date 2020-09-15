using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenTDB
{
    internal class QuestionResult : BaseResult
    {
        [JsonProperty("results")]
        internal List<EncodedQuestion> Questions { get; set; }
    }
}