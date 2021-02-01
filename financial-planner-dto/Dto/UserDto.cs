using System;

namespace FinancialPlanner.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string Password { get; set; }
    }
}
