using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOffice.Common.DTOs
{
    public class VisitorCard
    {
        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Guid VisitorId { get; set; }
        public Visitor Visitor { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
