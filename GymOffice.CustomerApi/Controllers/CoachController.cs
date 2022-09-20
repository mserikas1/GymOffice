using GymOffice.DataAccess.SQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymOffice.CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CoachController(ApplicationDbContext context)
        {
           _context= context;
        }
    }
}
