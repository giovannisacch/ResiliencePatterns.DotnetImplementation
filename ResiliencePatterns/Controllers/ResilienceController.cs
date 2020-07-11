using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResiliencePatterns.ExternalServices;

namespace ResiliencePatterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResilienceController : Controller
    {
        private readonly ITargetService _targetService;
        public ResilienceController(ITargetService targetService)
        {
            _targetService = targetService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(ERequestType requestType)
        {
            var response = await _targetService.CallTargetService(requestType);
            var responseContent = JsonSerializer.Deserialize<ResponseModel>(response.Content.ReadAsStringAsync().Result,
                new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
            if (response.StatusCode == HttpStatusCode.OK)
                return Ok(responseContent);
            
            return BadRequest(responseContent);
        }
    }
}