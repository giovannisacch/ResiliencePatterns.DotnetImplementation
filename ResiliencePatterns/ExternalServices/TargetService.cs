using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResiliencePatterns.ExternalServices
{
    public interface ITargetService
    {
        Task<ResponseModel> CallTargetService(ERequestType requestType);
    }
    public class TargetService : ITargetService
    {
        private readonly HttpClient _httpClient;
        public TargetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseModel> CallTargetService(ERequestType requestType)
        {
            var result = await _httpClient.GetStringAsync($"/?type={(int)requestType}");
            return JsonSerializer.Deserialize<ResponseModel>(result, new JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
        }
    }
}