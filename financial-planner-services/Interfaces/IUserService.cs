using System;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Services.Interfaces
{
    public interface IUserService
    {
        UserDto GetUser(int UserId);
    }
}
