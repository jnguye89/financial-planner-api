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

        public UserDto GetUserAsync(int UserId)
        {
            //var user = await DbContext.Users.FindAsync(UserId);
            //return user;
            var userModel = new User
            {
                FirstName = "Jackie",
                LastName = "Nguyen"
            };
            return Mapper.Map<UserDto>(userModel);
        }
    }
}
