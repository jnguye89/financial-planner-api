using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Interfaces
{
    public interface IBillsService
    {
        Task<List<BillDto>> GetBillsByUserId(int userId);
        Task CreateBill(BillDto bill);
        Task DeleteBill(int billId);
    }
}
