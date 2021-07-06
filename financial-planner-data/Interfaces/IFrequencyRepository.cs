using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Interfaces
{
    public interface IFrequencyRepository
    {
        Task<List<FrequencyDto>> GetFrequencies();
    }
}
