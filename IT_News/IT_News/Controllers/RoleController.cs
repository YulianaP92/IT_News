using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IT_News.Models;
using Microsoft.AspNet.Identity.Owin;


namespace IT_News.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationUserManager _userManager;

        public RoleController()
        {
                
        }
        public RoleController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }            
        }

        public async Task<ActionResult> Edit(string userId)
        {
            // получаем пользователя
            var user = await UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await UserManager.GetRolesAsync(userId);
                var allRoles = ApplicationDbContext.Create().Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(string userId, List<string> roles)
        {           
            // получаем пользователя
            var user = await UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await UserManager.GetRolesAsync(userId);
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles).ToArray();
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles).ToArray();

                await UserManager.AddToRolesAsync(userId, addedRoles);

                await UserManager.RemoveFromRolesAsync(userId, removedRoles);

                return RedirectToAction("Index", "Home");
            }
            return HttpNotFound();
        }
    }
}