using System;
namespace FinancialPlanner.Data.Models
{
    public class UserBalance
    {
        public int UserBalanceId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
    }
}
