﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOffice.Common.DTOs
{
    public class TrainingVisit
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Abonnement Abonnement { get; set; } = null!;
        public PersonalTraining? PersonalTraining { get; set; }
        public GroupTraining? GroupTraining { get; set; }
    }
}