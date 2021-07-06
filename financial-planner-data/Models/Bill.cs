using System;
namespace FinancialPlanner.Data.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public string Name { get; set; }
        public int FrequencyId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public int? RepetitionDay { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }
        public Frequency Frequency { get; set; }
        public User User { get; set; }
    }
}
