using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAuthenticationRepository
    { 
        Task<SignInResult> Login(string email, string password);
        Task<IdentityResult> CreateAccount(ApplicationUser applicationUser, string password);
        Task Logout();

    }
}
