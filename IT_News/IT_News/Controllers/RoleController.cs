using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IT_News.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;


namespace IT_News.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationDbContext _context;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationUserManager _userManager;

        public RoleController()
        {
                
        }
        public RoleController(RoleManager<IdentityRole> roleManager, ApplicationUserManager userManager)
        {
            
            _roleManager = roleManager;
            UserManager = userManager;
        }
        //public RoleManager<IdentityRole> RoleManager
        //{
        //    get
        //    {
        //        return _roleManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
        //    }
        //    private set
        //    {
        //        _roleManager = value;
        //    }
        //}

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
            _context = new ApplicationDbContext();//??????????????????????????????????????
            // получаем пользователя
            var user = await UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await UserManager.GetRolesAsync(userId);
                var allRoles = _context.Roles.ToList();
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

    }
}