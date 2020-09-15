using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenTDB
{
    internal class CategoryCollection
    {
        [JsonProperty("trivia_categories")]
        public List<TriviaCategory> Categories { get; }
    }
}