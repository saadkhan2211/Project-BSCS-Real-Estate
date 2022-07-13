using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_BSCS.Data;
using Project_BSCS.Models;
using Project_BSCS.Repository;

namespace Project_BSCS.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegisterRepository _registerRepository;

        public RegistrationController(IRegisterRepository registerRepository)
        {
            this._registerRepository = registerRepository;
        }

        [Route("signup")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                var result = await _registerRepository.CreateUserAsync(registration);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    TempData["success"] = "Registered Successfully";
                    return View(registration);
                }
                ModelState.Clear();
            }
            TempData["success"] = "Registered Successfully";
            return View();
        }
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await _registerRepository.PasswordSignInAsync(login);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invaild Credentials");
            }
            return View();
        }
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _registerRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
