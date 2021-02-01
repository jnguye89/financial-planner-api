using System;
namespace FinancialPlanner.Dto
{
    public class BillDto
    {
        public int BillId { get; set; }
        public string Description { get; set; }
        public FrequencyDto Frequency { get; set; }
    }
}
