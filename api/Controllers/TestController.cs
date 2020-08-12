using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vinynvest.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Pikachu()
        {
            return "OK Easynvest";
        }
    }
}