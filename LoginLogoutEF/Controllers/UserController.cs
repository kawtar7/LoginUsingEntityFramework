using LoginLogoutEF.Data;
using LoginLogoutEF.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginLogoutEF.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDbContext _userDbContext;

        public UserController( UserDbContext userDbContext)
        {
        
            _userDbContext = userDbContext;
        }
       

        public IActionResult Index()
        {
            List<User> users = _userDbContext.Users.ToList();
            return View(users);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = _userDbContext.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == model.Password);

                if (user != null)
                {
                    
                    return RedirectToAction("Index");
                }

               
                ModelState.AddModelError(string.Empty, "Identifiant ou mot de passe incorrect.");
            }

            
            return View(model);
        }
    }
}
