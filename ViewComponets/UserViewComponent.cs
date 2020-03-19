using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewCompDemo.Services;

namespace ViewCompDemo.ViewComponets
{
    public class UserViewComponent : ViewComponent
    {
        private readonly IUserService mUserService;
        public UserViewComponent(IUserService userService)
        {
            mUserService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var user = await mUserService.GetUserAsync(id);
            return View(user);
        }
    }
}