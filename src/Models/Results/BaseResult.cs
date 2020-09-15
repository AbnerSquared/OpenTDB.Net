using Newtonsoft.Json;

namespace OpenTDB
{
    internal class BaseResult
    {
        [JsonProperty("response_code")]
        internal ResponseCode ResponseCode { get; set; }
    }
}