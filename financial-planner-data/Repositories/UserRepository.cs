using System.Threading.Tasks;
using AutoMapper;
using FinancialPlanner.Data.Data;
using FinancialPlanner.Data.Interfaces;
using FinancialPlanner.Data.Models;
using FinancialPlanner.Dto;

namespace FinancialPlanner.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public FinancialPlannerContext DbContext;
        public IMapper Mapper;

        public UserRepository(FinancialPlannerContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public async Task<UserDto> GetUserAsync(int UserId)
        {
            var user = await DbContext.Users.FindAsync(UserId);
            return Mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var user = Mapper.Map<User>(userDto);
            DbContext.Add(user);
            await DbContext.SaveChangesAsync();
            return Mapper.Map(user, userDto);
        }
    }
}
