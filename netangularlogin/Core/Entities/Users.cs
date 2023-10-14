using Microsoft.AspNetCore.Identity;
using netangularlogin.Core.Entities;

namespace netangularlogin.Core.Entities
{
    public class Users : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}