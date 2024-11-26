using Harmic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Harmic.Controllers
{
    public class PostBlogComments : Controller
    {
        private readonly HarmicContext _context;
        public PostBlogComments(HarmicContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IActionResult> CreateCMT(string name, string phone, string email, string detail, int blogId)
        {
            try
            {
                TbBlogComment contact = new TbBlogComment
                {
                    BlogId = blogId,
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Detail = detail,
                    CreatedDate = DateTime.Now
                };

                await _context.AddAsync(contact);
                await _context.SaveChangesAsync();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }

    }
}
