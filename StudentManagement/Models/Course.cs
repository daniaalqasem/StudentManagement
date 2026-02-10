namespace StudentManagement.Models
{
    // يمثل مادة دراسية
    public class Course
    {
        public int Id { get; set; }                // رقم المادة
        public string Title { get; set; }          // اسم المادة
        public int Credits { get; set; }           // عدد الساعات
        public string SectionNumber { get; set; }  // رقم الشعبة
        public string Schedule { get; set; }       // وقت المحاضرة

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
