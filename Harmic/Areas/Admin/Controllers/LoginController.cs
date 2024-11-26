using Harmic.Areas.Admin.Models;
using Harmic.Models;
using Harmic.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Harmic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        public readonly HarmicContext _context;
        public LoginController(HarmicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]

        public IActionResult Index(AdminUser user)
        {
            if(user == null)
            {
                return NotFound();
            }

            string pw = Function.MD5Password(user.Password);

            var check = _context.AdminUsers.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
           if(check == null)
            {
                Function._Message = "Invalid User or password";
                return RedirectToAction("Index", "Login");
            }

           
            Function._Message = string.Empty;
            Function._UserID = check.UserID;
            Function._Username = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Function._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;

            return RedirectToAction("Index", "Home");
        }
    }
}
