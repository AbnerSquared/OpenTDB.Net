using Newtonsoft.Json;

namespace OpenTDB
{
    internal class ResetResult : BaseResult
    {
        [JsonProperty("token")]
        internal string Token { get; set; }
    }
}