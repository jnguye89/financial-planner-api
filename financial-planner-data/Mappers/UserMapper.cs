using System;
using AutoMapper;
using FinancialPlanner.Data.Models;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Data.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}