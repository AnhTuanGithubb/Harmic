using Harmic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Harmic.Controllers
{
    public class ContactController : Controller
    {
        private readonly HarmicContext _context;
        public ContactController(HarmicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(string name, string phone, string email, string message)
        {
            try
            {
                TbContact contact = new TbContact
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Message = message,
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
