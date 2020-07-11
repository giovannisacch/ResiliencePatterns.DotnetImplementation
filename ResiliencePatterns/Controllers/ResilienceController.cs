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
            return Ok(await _targetService.CallTargetService(requestType));
        }
    }
}