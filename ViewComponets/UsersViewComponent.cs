using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewCompDemo.Services;

namespace ViewCompDemo.ViewComponets
{
    public class UsersViewComponent : ViewComponent
    {
        // HH: Code part of the View Componenet (Users)
        private readonly IUserService mUserService;
        public UsersViewComponent(IUserService userService)
        {
            mUserService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await mUserService.GetUserAsync();
            return View(users);
        }
    }
}