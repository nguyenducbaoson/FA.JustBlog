using static FA.JustBlog.Utility.SD;

namespace FA.JustBlog.API.Models
{
    public class APIRequest
    {
        public apiType ApiType { get; set; } = apiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
