using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSmonder.Data.Entities.Idenity;
using WebSmonder.Models.Account;

namespace WebSmonder.ViewComponents
{
    public class UserLinkViewComponent(UserManager<UserEntity> userManager,
        IMapper mapper) 
        : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity?.Name;
            var model = new UserLinkViewModel();

            if (userName != null)
            {
                var user = userManager.FindByNameAsync(userName).Result;
                model = mapper.Map<UserLinkViewModel>(user);
            }
            return View(model);
        }
    }
}
