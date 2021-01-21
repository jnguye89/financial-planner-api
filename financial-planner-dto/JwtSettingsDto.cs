using System;
namespace FinancialPlanner.Dto
{
    public class JwtSettingsDto
    {
        public string Secret { get; set; }
        public int Expiration { get; set; }
    }
}
