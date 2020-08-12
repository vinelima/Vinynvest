using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Vinynvest.Application;

namespace Vinynvest.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class InvestmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        private readonly ILogger<InvestmentController> _logger;
        private readonly IInvestmentService _investmentService;
        private readonly string _mockyApi;
        public InvestmentController(IConfiguration configuration, IMemoryCache cache, ILogger<InvestmentController> logger, IInvestmentService investmentService)
        {
            _configuration = configuration;
            _cache = cache;
            _logger = logger;
            _investmentService = investmentService;
            _mockyApi = configuration.GetSection("AppSettings").GetSection("MockyApi").Value;
        }
        [HttpGet]
        public IActionResult ReturnInvestments()
        {
            try
            {
                DateTime tomorrow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 0, 0, 0);
                _logger.LogInformation(1, DateTime.Now.ToString() + " - Seeking investments...");
                var toMidnight = tomorrow.Subtract(DateTime.Now);
                var cacheEntry = _cache.GetOrCreate("TotalAmountKey", entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = toMidnight;
                    entry.SetPriority(CacheItemPriority.High);
                    _investmentService.InitializeClient(_mockyApi);
                    return _investmentService.ReturnInvestments();
                });
                return Ok(cacheEntry);
            }
            catch (Exception e)
            {
                _logger.LogError(1, DateTime.Now.ToString() + " - Error when searching for investments. Message: " + e.Message);
                return BadRequest();
            }
        }
    }
}