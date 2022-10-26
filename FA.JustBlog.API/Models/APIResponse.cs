using System.Net;

namespace FA.JustBlog.API.Models
{
    public class APIResponse
    {
        public APIResponse()
        {
            ErrorMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string RequestId { get; set; }
        public List<string> ErrorMessages { get; set; }

        public object Result { get; set; }
    }
}
