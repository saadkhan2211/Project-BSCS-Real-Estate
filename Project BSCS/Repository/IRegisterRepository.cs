using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_BSCS.Models;

namespace Project_BSCS.Repository
{
    public interface IRegisterRepository
    {
        Task<IdentityResult> CreateUserAsync(Registration registration);
        Task<Microsoft.AspNetCore.Identity.SignInResult> PasswordSignInAsync(Login login);
        Task SignOutAsync();
    }
}