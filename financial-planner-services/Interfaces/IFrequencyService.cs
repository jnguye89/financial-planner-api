using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Interfaces
{
    public interface IFrequencyService
    {
        Task<List<FrequencyDto>> GetFrequencies();
    }
}
