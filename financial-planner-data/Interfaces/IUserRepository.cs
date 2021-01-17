using System;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Data.Interfaces
{
    public interface IUserRepository
    {
        UserDto GetUserAsync(int UserId);
    }
}
