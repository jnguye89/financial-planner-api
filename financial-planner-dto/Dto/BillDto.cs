using System;
namespace FinancialPlanner.Dto
{
    public class BillDto
    {
        public int BillId { get; set; }
        public string Name { get; set; }
        public int FrequencyId { get; set; }
        public int UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public int? MonthlyStartDay { get; set; }
        public int? WeeklyStartDay { get; set; }
        public bool IsIncome { get; set; }
        public decimal Amount { get; set; }
        public FrequencyDto Frequency { get; set; }
        public UserDto User { get; set; }
    }
}
