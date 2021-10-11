using System;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Dto
{
    public class UserBalanceDto
    {
        public int UserBalanceId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public UserDto User { get; set; }
    }
}
