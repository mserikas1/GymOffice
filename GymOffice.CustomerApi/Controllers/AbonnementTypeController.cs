using GymOffice.Business.DataProviders;
using GymOffice.Common.Contracts.DataProviderContracts;
using GymOffice.Common.DTOs;
using GymOffice.CustomerApi.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymOffice.CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class AbonnementTypeController : ControllerBase
    {
        private readonly IAbonnementTypeDataProvider _dataProvider;
        public AbonnementTypeController(IAbonnementTypeDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        [HttpGet("[action]")]
        public IActionResult GetActiveAbonnementTypes()
        {
            ICollection<AbonnementType>? activeAbonTypes = _dataProvider.GetActiveAbonnementTypes();
            ICollection<GroupedAbonnementTypeVM>? groupedAbonTypes = activeAbonTypes?.GroupBy(a => new { a.Name, a.Description, a.StartVisitTime, a.EndVisitTime }).Select(g => new GroupedAbonnementTypeVM()
            {
                Name = g.Key.Name,
                Description = g.Key.Description,
                StartVisitTime = g.Key.StartVisitTime,
                EndVisitTime = g.Key.EndVisitTime,
                MinPrice = g.Select(i => i.Price).Min(),
            }).ToList();
            return Ok(groupedAbonTypes);
        }

    }
}
