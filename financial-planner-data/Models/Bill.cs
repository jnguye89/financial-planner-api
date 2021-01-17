using System;
namespace FinancialPlanner.Data.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public string Name { get; set; }
        public Frequency Frequency { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsIncome { get; set; }
    }
}
