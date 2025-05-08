using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSmonder.Data.Entities.Idenity;
using WebSmonder.Interfaces;
using WebSmonder.Models.Account;
using WebSmonder.Services;

namespace WebSmonder.Controllers
{
    public class AccountController(UserManager<UserEntity> userManager, 
        SignInManager<UserEntity> signInManager,
        IImageService imageService,
        IMapper mapper) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(!ModelState.IsValid) 
                return View(model);
            
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user!=null)
            {
                var res = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (res.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Redirect("/");
                }
                
            }
            ModelState.AddModelError("", "Дані вказано не вірно!");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = mapper.Map<UserEntity>(model);
            user.Image = await imageService.SaveImageAsync(model.Image) ?? null;

            var res = await userManager.CreateAsync(user, model.Password);
            if (res.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return Redirect("/");
            }
            foreach (var error in res.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
