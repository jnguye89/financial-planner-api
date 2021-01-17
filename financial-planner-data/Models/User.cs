using System;
using System.Collections.Generic;

namespace FinancialPlanner.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public List<Bill> Bills { get; set; }
    }
}
