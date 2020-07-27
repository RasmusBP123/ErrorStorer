using Domain;
using Domain.Repositories;
using Infrastructure.Storage;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuthentcationRepository : IAuthenticationRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DbStorage _context;

        public AuthentcationRepository(SignInManager<ApplicationUser> signInManager, DbStorage context, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAccount(ApplicationUser applicationUser, string password)
        {
            foreach (var user in _context.ApplicationUsers)
            {
                if(user.Email == applicationUser.Email) throw new Exception("User already exists");
            }

            var result = await _userManager.CreateAsync(applicationUser, password);
            return result;
        }

        public async Task<SignInResult> Login(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        } 
    }
}
