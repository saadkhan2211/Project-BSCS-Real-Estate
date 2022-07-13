using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_BSCS.Models;

namespace Project_BSCS.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RegisterRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(Registration registration)
        {
            var user = new ApplicationUser()
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Email = registration.Email,
                UserName = registration.Email,
                DateOfBirth = registration.DateOfBirth
            };
            var result = await _userManager.CreateAsync(user, registration.Password);
            return result;
        }
        public async Task<Microsoft.AspNetCore.Identity.SignInResult> PasswordSignInAsync(Login login)
        {
            return await _signInManager.PasswordSignInAsync(login.Log_email, login.Log_pass, login.Log_Rem, false);
        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
