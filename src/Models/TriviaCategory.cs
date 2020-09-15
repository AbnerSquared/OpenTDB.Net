using Newtonsoft.Json;

namespace OpenTDB
{
    public class TriviaCategory
    {
        [JsonConstructor]
        public TriviaCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [JsonProperty("id")]
        public int Id { get; }

        [JsonProperty("name")]
        public string Name { get; }
    }
}
