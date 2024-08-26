namespace StudentPortal.Models.Students
{
    public class StudentList
    {
        public static List<Student> StudentsList { get; set; } = new List<Student>();
    }

    public class Student
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Subscribed { get; set; }
    }
}
