using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPlanner.Dto;
using FinancialPlanner.Interfaces;
using FinancialPlanner.Repositories;

namespace FinancialPlanner.Services
{
    public class BillsService : IBillsService
    {
        public IBillsRepository BillsRepository;

        public BillsService(IBillsRepository billsRepository)
        {
            BillsRepository = billsRepository;
        }

        public async Task<List<BillDto>> GetBillsByUserId(int userId)
        {
            return await BillsRepository.GetBillsByUserId(userId);
        }

        public async Task CreateBill(BillDto bill)
        {
            await BillsRepository.CreateBill(bill);
        }
    }
}
