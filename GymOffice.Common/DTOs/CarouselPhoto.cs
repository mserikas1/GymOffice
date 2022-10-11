using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOffice.Common.DTOs
{
    public class CarouselPhoto
    {
        public int Id { get; set; }     // also can serve as the number in order
        public string PhotoUrl { get; set; } = null!;

    }
}
