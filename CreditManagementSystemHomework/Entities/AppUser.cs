using Microsoft.AspNetCore.Identity;

namespace CreditManagementSystemHomework.Entities
{
    public class AppUser:IdentityUser
    {
        public string LastLoginIpAdr { get; set; }
    }
}
