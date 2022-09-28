using GymOffice.Business.DataProviders;
using GymOffice.Common.Contracts.DataProviderContracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymOffice.CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class AbonnementController : ControllerBase
    {
        private readonly IAbonnementDataProvider _dataProvider;
        public AbonnementController(IAbonnementDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

    }
}
