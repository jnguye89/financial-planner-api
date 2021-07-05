using System;
using AutoMapper;
using FinancialPlanner.Data.Models;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Mappers
{
    public class BillMapper : Profile
    {
        public BillMapper()
        {
            CreateMap<Bill, BillDto>();
            CreateMap<BillDto, Bill>();
        }
    }
}
