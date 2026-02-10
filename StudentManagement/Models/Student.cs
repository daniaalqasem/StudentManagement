
using Microsoft.AspNetCore.Identity;

namespace StudentManagement.Models
{
    // يمثل طالب
    public class Student
    {
        public int Id { get; set; }                // رقم الطالب
        public string FullName { get; set; }       // الاسم الكامل
        public string Email { get; set; }          // البريد الإلكتروني
                                                   // ربط مع AspNetUsers
   public string UserId { get; set; }
        public IdentityUser User { get; set; }
        // علاقة Many-to-Many مع المواد عبر Enrollment
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}

