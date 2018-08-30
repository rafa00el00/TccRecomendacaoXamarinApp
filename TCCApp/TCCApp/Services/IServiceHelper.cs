using System.Net.Http;
using System.Threading.Tasks;

namespace TCCApp.Services
{
    public interface IServiceHelper
    {
        string BaseUrl { get; }
        HttpClient Http { get; }

        Task<HttpResponseMessage> Delete(string url);
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> Patch(string url, HttpContent content);
        Task<HttpResponseMessage> Post(string url, HttpContent content);
        Task<HttpResponseMessage> Put(string url, HttpContent content);
    }
}