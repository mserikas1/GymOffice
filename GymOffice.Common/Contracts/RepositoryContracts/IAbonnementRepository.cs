﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOffice.Common.Contracts.RepositoryContracts
{
    public interface IAbonnementRepository
    {
        ICollection<Abonnement>? GetAbonnementsById(Guid id);
    }
}