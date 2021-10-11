using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Interfaces
{
    public interface IBillsRepository
    {
        Task<List<BillDto>> GetBillsByUserId(int UserId, DateTime startDate);
        Task CreateBill(BillDto bill);
        Task DeleteBill(int billId);
    }
}