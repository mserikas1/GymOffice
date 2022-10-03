using GymOffice.Business.DataProviders;
using GymOffice.Common.Contracts.DataProviderContracts;
using GymOffice.Common.DTOs;
using GymOffice.CustomerApi.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            List<GroupedAbonnementTypeVM>? groupedAbonTypes = activeAbonTypes?.GroupBy(a => new { a.Name, a.Description, a.StartVisitTime, a.EndVisitTime }).Select(g => new GroupedAbonnementTypeVM()
            {
                Name = g.Key.Name,
                Description = g.Key.Description,
                StartVisitTime = g.Key.StartVisitTime,
                EndVisitTime = g.Key.EndVisitTime,
                Prices = g.Select(i => i.Price).ToList(),
                Durations = g.Select(i=>(int)i.Duration).ToList()
            }).ToList();
            for (int i = 0; i < groupedAbonTypes?.Count; i++)
            {
                for (int j = 0; j < groupedAbonTypes[i].Prices.Count; j++)
                {
                    groupedAbonTypes[i].PricesPerDurs.Add(groupedAbonTypes[i].Durations[j], groupedAbonTypes[i].Prices[j]);
                }
            }
            return Ok(JsonConvert.SerializeObject(groupedAbonTypes, Formatting.Indented));
        }

    }
}
