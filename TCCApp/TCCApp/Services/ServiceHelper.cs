using System.Net.Http;
using System.Threading.Tasks;

namespace TCCApp.Services
{

   

    public class ServiceHelper
    {

        
        public ServiceHelper()
        {
            Http = new HttpClient();
            BaseUrl = "";
        }

        public HttpClient Http { get; }
        public string BaseUrl { get; }

        public Task<HttpResponseMessage> Get(string url)
        {
            return Http.GetAsync(BaseUrl + url);
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
