using GymOffice.Common.Contracts.DataProviderContracts;
using GymOffice.Common.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static System.Net.WebRequestMethods;

namespace GymOffice.VisitorCabinet.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CarouselPhotoController : ControllerBase
    {
        private readonly ICarouselPhotoDataProvider _carouselPhotoDataProvider;
        private readonly IConfiguration _configuration;
        public CarouselPhotoController(ICarouselPhotoDataProvider carouselPhotoDataProvider, IConfiguration configuration)
        {
            _carouselPhotoDataProvider = carouselPhotoDataProvider;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult GetCarouselPhotos()
        {
            ICollection<CarouselPhoto>? photos = _carouselPhotoDataProvider.GetAllCarouselPhotosAsync().Result;
            if (photos == null)
                return Ok("No carousel photos found");
            List<string> photoUrls = photos.Select(photo => photo.PhotoUrl).ToList();
            if (photoUrls != null)
            {
                for (int i = 0; i < photoUrls.Count; i++)
                {
                    photoUrls[i] = "https://localhost:7089/" + photoUrls[i];
                    //photoUrls[i] = _configuration["PhotoUrl"]+photoUrls[i];
                }
                return Ok(photoUrls);
            }
            else
                return Ok("No carousel photos found");
        }

    }
}
