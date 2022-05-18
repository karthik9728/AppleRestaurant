using static Apple.Web.SD;

namespace Apple.Web.Models.ApiRequest
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        //public UriBuilder Url { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
