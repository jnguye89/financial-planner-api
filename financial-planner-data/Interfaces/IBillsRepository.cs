using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Interfaces
{
    public interface IBillsRepository
    {
        Task<List<BillDto>> GetBillsByUserId(int UserId);
        Task CreateBill(BillDto bill);
    }
}
