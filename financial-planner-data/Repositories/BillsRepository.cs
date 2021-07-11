using AutoMapper;
using FinancialPlanner.Interfaces;
using FinancialPlanner.Data.Data;
using System.Collections.Generic;
using FinancialPlanner.Dto;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FinancialPlanner.Data.Models;

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

        public async Task<List<BillDto>> GetBillsByUserId(int UserId)
        {
            var bills = await DbContext.Bills.Include(b => b.Frequency).Where(bill => bill.UserId == UserId).ToListAsync();
            return Mapper.Map<List<BillDto>>(bills);
        }

        public async Task CreateBill(BillDto bill)
        {
            var entity = Mapper.Map<Bill>(bill);
            var billEntity = DbContext.Bills.Add(entity);
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
