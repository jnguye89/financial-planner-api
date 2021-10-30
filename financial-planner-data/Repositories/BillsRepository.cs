using AutoMapper;
using FinancialPlanner.Interfaces;
using FinancialPlanner.Data.Data;
using System.Collections.Generic;
using FinancialPlanner.Dto;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FinancialPlanner.Data.Models;
using System;
using FinancialPanner.Enums;

namespace FinancialPlanner.Repositories
{
    public class BillsRepository : IBillsRepository
    {
        public FinancialPlannerContext DbContext;
        public IMapper Mapper;

        public BillsRepository(FinancialPlannerContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public async Task<List<BillDto>> GetBillsByUserId(int UserId, DateTime startDate)
        {
            var bills = await DbContext.Bills.Include(b => b.Frequency)
                .Where(bill =>
                    bill.UserId == UserId
                    && ((bill.FrequencyId == (int)FrequencyEnum.Single && bill.StartDate >= startDate)
                        || (bill.FrequencyId != (int)FrequencyEnum.Single && bill.EndDate.Value == null)
                        || (bill.FrequencyId != (int)FrequencyEnum.Single && bill.EndDate.Value > DateTime.Now)))
                .ToListAsync();
            return Mapper.Map<List<BillDto>>(bills);
        }

        public async Task CreateBill(BillDto bill)
        {
            var entity = Mapper.Map<Bill>(bill);
            var billEntity = DbContext.Bills.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateBill(BillDto billDto)
        {
            var entity = Mapper.Map<Bill>(billDto);
            var bill = await DbContext.Bills.FindAsync(billDto.BillId);
            bill.EndDate = entity.EndDate;
            bill.Amount = entity.Amount;
            bill.FrequencyId = entity.FrequencyId;
            bill.IsIncome = entity.IsIncome;
            bill.Name = entity.Name;
            bill.RepetitionDay = entity.RepetitionDay;
            bill.StartDate = entity.StartDate;
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteBill(int billId)
        {
            var entity = await DbContext.Bills.Where(bill => bill.BillId == billId).FirstOrDefaultAsync();
            DbContext.Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
