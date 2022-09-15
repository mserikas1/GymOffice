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
        public Visitor Visitor { get; set; } = null!;
        public string BarCode { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Admin CreatedBy { get; set; } = null!;
        public ICollection<Abonnement> Abonnements { get; set; } = new List<Abonnement>();
    }
}
