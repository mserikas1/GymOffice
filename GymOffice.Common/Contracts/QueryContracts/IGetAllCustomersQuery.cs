﻿namespace GymOffice.Common.Contracts.QueryContracts;
public interface IGetAllCustomersQuery
{
    Task<IEnumerable<Customer>?> Execute();
}
