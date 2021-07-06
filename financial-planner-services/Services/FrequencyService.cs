using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPlanner.Dto;
using FinancialPlanner.Interfaces;

namespace FinancialPlanner.Services
{
    public class FrequencyService : IFrequencyService
    {
        public IFrequencyRepository FrequencyRepository;

        public FrequencyService(IFrequencyRepository frequencyRepository)
        {
            FrequencyRepository = frequencyRepository;
        }

        public async Task<List<FrequencyDto>> GetFrequencies()
        {
            return await FrequencyRepository.GetFrequencies();
        }
    }
}
