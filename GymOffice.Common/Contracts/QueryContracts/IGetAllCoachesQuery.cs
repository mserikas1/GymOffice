﻿namespace GymOffice.Common.Contracts.QueryContracts;
public interface IGetAllCoachesQuery
{
    Task<IEnumerable<Coach>?> Execute();
}
