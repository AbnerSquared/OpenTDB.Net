using Newtonsoft.Json;

namespace OpenTDB
{
    internal class ResponseResult : BaseResult
    {
        [JsonProperty("response_message")]
        internal string ResponseMessage { get; set; }
    }
}