using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOffice.Common.DTOs
{
    public class Advantage
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public Admin CreatedBy { get; set; } = null!;
        public Admin ModifiedBy { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
