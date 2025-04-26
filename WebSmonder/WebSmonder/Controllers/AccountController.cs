using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSmonder.Data.Entities.Idenity;
using WebSmonder.Models.Account;

namespace WebSmonder.Controllers
{
    public class AccountController(UserManager<UserEntity> userManager, 
        SignInManager<UserEntity> signInManager) : Controller
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
    }
}
