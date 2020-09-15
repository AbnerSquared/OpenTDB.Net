using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenTDB
{
    public class CountResult
    {
        [JsonProperty("overall")]
        public QuestionCount Overall { get; internal set; }

        [JsonProperty("categories")]
        public Dictionary<int, QuestionCount> Categories { get; internal set; }
    }
}