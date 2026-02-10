using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    // هذا الكلاس يمثل قاعدة البيانات ويربط الموديلات بالجداول
    public class ApplicationDbContext : IdentityDbContext
    {
        // الكونستركتور: يمرر خيارات الاتصال للـ DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // جداولنا المخصصة
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
