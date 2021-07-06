using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinancialPlanner.Data.Data;
using FinancialPlanner.Dto;
using FinancialPlanner.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialPlanner.Repositories
{
    public class FrequencyRepository : IFrequencyRepository
    {
        public FinancialPlannerContext DbContext;
        public IMapper Mapper;

        public FrequencyRepository(FinancialPlannerContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public async Task<List<FrequencyDto>> GetFrequencies()
        {
            var frequencies = await DbContext.Frequencies.ToListAsync();
            return Mapper.Map<List<FrequencyDto>>(frequencies);
        }
    }
}
