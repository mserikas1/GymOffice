
using GymOffice.Business.DataProviders;
using GymOffice.Common.Contracts.DataProviderContracts;
using GymOffice.Common.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace GymOffice.VisitorCabinet.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class AdvantageController : ControllerBase
    {
        private readonly IAdvantageDataProvider _dataProvider;
        private readonly IConfiguration _configuration;
        public AdvantageController(IAdvantageDataProvider dataProvider, IConfiguration configuration)
        {
            _dataProvider = dataProvider;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> GetAdvantages()
        {
            var advantages = await _dataProvider.GetAdvantagesAsync();
            if (advantages != null)
            {
                foreach (var advantage in advantages)
                {
                    advantage.PhotoUrl = "https://localhost:7089/" + advantage.PhotoUrl;
                }
                return Ok(advantages);
            }
            else
                return Ok("No advantages found");
        }
    }
}
