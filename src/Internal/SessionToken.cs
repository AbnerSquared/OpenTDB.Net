using Newtonsoft.Json;

namespace OpenTDB
{
    internal class SessionToken : ResponseResult
    {
        [JsonProperty("token")]
        internal string Token { get; set; }
    }
}