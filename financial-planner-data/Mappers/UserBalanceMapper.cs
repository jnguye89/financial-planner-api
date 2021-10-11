using System;
using AutoMapper;
using FinancialPlanner.Data.Models;
using FinancialPlanner.Dto;

namespace financial_planner_data.Mappers
{
    public class UserBalanceMapper : Profile
    {
        public UserBalanceMapper()
        {
            CreateMap<UserBalance, UserBalanceDto>();
            CreateMap<UserBalanceDto, UserBalance>();
        }
    }
}
