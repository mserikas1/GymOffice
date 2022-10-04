using GymOffice.Business.DataProviders;
using GymOffice.Common.Contracts.DataProviderContracts;
using GymOffice.DataAccess.SQL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymOffice.CustomerApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachDataProvider _coachDataProvider;
        public CoachController(ICoachDataProvider coachDataProvider)
        {
            _coachDataProvider = coachDataProvider;
        }
        [HttpGet]
        public IActionResult GetActiveCoaches() => Ok(_coachDataProvider.GetActiveCoaches());

    }
}
