using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models;
using System.Linq;
using System.Collections.Generic;

namespace StudentManagement.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ÚÑÖ ÌãíÚ ÇáãæÇÏ ÇáãÊÇÍÉ
        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        // ÊÓÌíá ãÇÏÉ ááØÇáÈ ÇáÍÇáí
        [HttpPost]
        public IActionResult Register(int id)
        {
            var userEmail = User.Identity.Name; // ÇáÈÑíÏ ÇáÅáßÊÑæäí ááÍÓÇÈ ÇáÍÇáí
            var student = _context.Students.FirstOrDefault(s => s.Email == userEmail);

            if (student == null)
            {
                return RedirectToAction("RegisteredCourses");
            }

            // ÊÍÞÞ ÅÐÇ ÇáØÇáÈ ãÓÌá ÇáãÇÏÉ ãÓÈÞðÇ
            var alreadyRegistered = _context.Enrollments
                .Any(e => e.StudentId == student.Id && e.CourseId == id);

            if (!alreadyRegistered)
            {
                var enrollment = new Enrollment
                {
                    StudentId = student.Id,
                    CourseId = id
                };

                _context.Enrollments.Add(enrollment);
                _context.SaveChanges();
            }

            // ÈÚÏ ÇáÊÓÌíá¡ ÑÌæÚ áÕÝÍÉ ÇáãæÇÏ ÇáãÓÌáÉ
            return RedirectToAction("RegisteredCourses");
        }

        // ÚÑÖ ÇáãæÇÏ ÇáãÓÌáÉ ááØÇáÈ ÇáÍÇáí (ÊÈÏÃ ÝÇÖíÉ)
        public IActionResult RegisteredCourses()
        {
            var userEmail = User.Identity.Name;
            var student = _context.Students.FirstOrDefault(s => s.Email == userEmail);

            if (student == null)
            {
                return View(new List<Course>()); // ÕÝÍÉ ÝÇÖíÉ ÅÐÇ ÇáØÇáÈ ãÔ ãæÌæÏ
            }

            var courses = _context.Enrollments
                .Where(e => e.StudentId == student.Id)
                .Select(e => e.Course)
                .ToList();

            return View(courses);
        }

        // ÅÖÇÝÉ ãæÇÏ ÊÌÑíÈíÉ (ááÊÌÑÈÉ ÝÞØ)
        public IActionResult AddSampleCourses()
        {
            _context.Courses.Add(new Course { Title = "ÈÑãÌÉ ÔÈßÇÊ", Credits = 3, SectionNumber = "1", Schedule = "ÇáÃÍÏ 10:00 - 12:00" });
            _context.Courses.Add(new Course { Title = "ÞæÇÚÏ ÈíÇäÇÊ", Credits = 4, SectionNumber = "2", Schedule = "ÇáËáÇËÇÁ 12:00 - 14:00" });
            _context.SaveChanges();

            return RedirectToAction("Index");
        }





        // ÍÐÝ ãÇÏÉ ãÓÌáÉ
        [HttpPost]
        public IActionResult Unregister(int id)
        {
            var userEmail = User.Identity.Name;
            var student = _context.Students.FirstOrDefault(s => s.Email == userEmail);

            if (student == null)
            {
                return RedirectToAction("RegisteredCourses");
            }

            var enrollment = _context.Enrollments
                .FirstOrDefault(e => e.StudentId == student.Id && e.CourseId == id);

            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                _context.SaveChanges();
            }

            return RedirectToAction("RegisteredCourses");
        }

    }
}
