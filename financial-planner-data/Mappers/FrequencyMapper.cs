using System;
using AutoMapper;
using FinancialPlanner.Data.Models;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Mappers
{
    public class FrequencyMapper : Profile
    {
        public FrequencyMapper()
        {
            CreateMap<Frequency, FrequencyDto>();
            CreateMap<FrequencyDto, Frequency>();
        }
    }
}
