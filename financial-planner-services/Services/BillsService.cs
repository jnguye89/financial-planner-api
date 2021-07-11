using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialPanner.Enums;
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

        public async Task DeleteBill(int billId)
        {
            await BillsRepository.DeleteBill(billId);
        }
    }
}
