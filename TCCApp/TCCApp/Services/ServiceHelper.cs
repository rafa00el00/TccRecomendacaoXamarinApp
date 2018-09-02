using System.Net.Http;
using System.Threading.Tasks;

namespace TCCApp.Services
{

   

    public class ServiceHelper : IServiceHelper
    {

        
        public ServiceHelper()
        {
            Http = new HttpClient();
            BaseUrl = "http://192.168.137.1:5000/api";
        }

        public HttpClient Http { get; }
        public string BaseUrl { get; }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await Http.GetAsync(BaseUrl + url);
        }

        public Task<HttpResponseMessage> Post(string url, HttpContent content)
        {
            return Http.PostAsync(BaseUrl + url, content);
        }

        public Task<HttpResponseMessage> Put(string url, HttpContent content)
        {
            return Http.PutAsync(BaseUrl + url, content);
        }

        public Task<HttpResponseMessage> Patch(string url, HttpContent content)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, BaseUrl + url)
            {
                Content = content
            };

            return Http.SendAsync(request);
        }


        public Task<HttpResponseMessage> Delete(string url)
        {
            return Http.DeleteAsync(BaseUrl + url);
        }
    }
}
