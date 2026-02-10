using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models;
using System.Linq;

namespace StudentManagement.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public StudentsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // ’›Õ… „⁄·Ê„«  «·ÿ«·»
        public IActionResult Profile()
        {
            var userId = _userManager.GetUserId(User);
            var userEmail = User.Identity.Name; // «·»—Ìœ «·≈·ﬂ —Ê‰Ì ··Õ”«» «·Õ«·Ì

            // «»ÕÀ ⁄‰ «·ÿ«·» »«·»—Ìœ «·≈·ﬂ —Ê‰Ì
            var student = _context.Students.FirstOrDefault(s => s.Email == userEmail);

            if (student != null)
            {
                // «—»ÿ «·ÿ«·» »«·Õ”«» ≈–« „‘ „—»Êÿ
                if (string.IsNullOrEmpty(student.UserId))
                {
                    student.UserId = userId;
                    _context.SaveChanges();
                }
            }

            return View(student);
        }


        // »œ¡ «· ”ÃÌ· «·≈·ﬂ —Ê‰Ì
        [HttpPost]
        public IActionResult StartRegistration(int id)
        {
            return RedirectToAction("Index", "Courses");
        }
    }
}
