using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPanner.Enums;
using FinancialPlanner.Dto;
using FinancialPlanner.Interfaces;

namespace FinancialPlanner.Services
{
    public class BillsService : IBillsService
    {
        private IBillsRepository BillsRepository;
        private IUserBalanceService UserBalanceService;

        public BillsService(IBillsRepository billsRepository, IUserBalanceService userBalanceService)
        {
            BillsRepository = billsRepository;
            UserBalanceService = userBalanceService;
        }

        public async Task<List<BillDto>> GetBillsByUserId(int userId)
        {
            var userBalance = await UserBalanceService.GetUserBalance(userId);
            return await BillsRepository.GetBillsByUserId(userId, userBalance.Date);
        }

        public async Task CreateBill(BillDto bill)
        {
            if (bill.FrequencyId == (int)FrequencyEnum.Yearly)
            {
                bill.RepetitionDay = bill.StartDate.DayOfYear;
                if (DateTime.IsLeapYear(bill.StartDate.Year) && bill.StartDate.DayOfYear > 59)
                    bill.RepetitionDay--;
            } else if (bill.FrequencyId == (int)FrequencyEnum.Monthly)
            {
                bill.RepetitionDay = bill.StartDate.Day;
            } else if (bill.FrequencyId == (int)FrequencyEnum.Biweekly || bill.FrequencyId == (int)FrequencyEnum.Weekly)
            {
                bill.RepetitionDay = (int)bill.StartDate.DayOfWeek;
            }
            await BillsRepository.CreateBill(bill);
        }

        public async Task UpdateBill(BillDto bill)
        {
            await BillsRepository.UpdateBill(bill);
        }

        public async Task DeleteBill(int billId)
        {
            await BillsRepository.DeleteBill(billId);
        }
    }
}
