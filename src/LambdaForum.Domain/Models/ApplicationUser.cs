using Microsoft.AspNetCore.Identity;

namespace LambdaForum.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }
    }
}
