
using FA.JustBlog.Service.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Service.Services
{
    public class BaseService 
    {
        //public IHttpClientFactory HttpClient { get; set; }
        ////public APIResponse responseModel { get; set; }
        //public BaseService(IHttpClientFactory httpClient)
        //{
        //    this.responseModel = new();
        //    this.HttpClient = httpClient;
        //}

        //public async Task<T> SendAsync<T>(APIRequest aPIRequest)
        //{
        //    try
        //    {
        //        var client = HttpClient.CreateClient("JustBlogAPI");
        //        HttpRequestMessage message = new HttpRequestMessage();
        //        message.Headers.Add("Accept", "application/json");
        //        message.RequestUri = new Uri(aPIRequest.Url);
        //        if (aPIRequest.Data != null)
        //        {
        //            message.Content = new StringContent(JsonConvert.SerializeObject(aPIRequest.Data), Encoding.UTF8, "application/json");
        //        }
        //        switch (aPIRequest.ApiType)
        //        {
        //            case SD.apiType.POST:
        //                message.Method = HttpMethod.Post;
        //                break;
        //            case SD.apiType.PUT:
        //                message.Method = HttpMethod.Put;
        //                break;
        //            case SD.apiType.DELETE:
        //                message.Method = HttpMethod.Delete;
        //                break;
        //            default:
        //                message.Method = HttpMethod.Get;
        //                break;
        //        }
        //        HttpResponseMessage apiResponse = null;
        //        apiResponse = await client.SendAsync(message);
        //        var apiContent = await apiResponse.Content.ReadAsStringAsync();
        //        var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
        //        return APIResponse;
        //    }
        //    catch (Exception e)
        //    {
        //        var dto = new APIResponse
        //        {
        //            ErrorMessages = new List<string> { Convert.ToString(e.Message) },
        //            IsSuccess = true
        //        };
        //        var res = JsonConvert.SerializeObject(dto);
        //        var APIResponse = JsonConvert.DeserializeObject<T>(res);
        //        return APIResponse;
        //    }
        //}
    }
}
