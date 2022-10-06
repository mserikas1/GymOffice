using GymOffice.Common.Contracts.DataProviderContracts;
using GymOffice.Common.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymOffice.VisitorCabinet.Controllers
{
    [Route("[controller]/[action]")]
    [EnableCors]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachDataProvider _coachDataProvider;
        private readonly IConfiguration _configuration;
        public CoachController(ICoachDataProvider coachDataProvider, IConfiguration configuration)
        {
            _coachDataProvider = coachDataProvider;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult GetActiveCoaches()
        {
            ICollection<Coach> activeCoaches = _coachDataProvider.GetActiveCoaches();
            if (activeCoaches != null)
            {
                foreach (var coach in activeCoaches)
                {
                    coach.PhotoUrl =_configuration["PhotoUrl"]+coach.PhotoUrl;
                }
                return Ok(activeCoaches);
            }
            else
                return Ok("No coaches found");
        }

    }
}
