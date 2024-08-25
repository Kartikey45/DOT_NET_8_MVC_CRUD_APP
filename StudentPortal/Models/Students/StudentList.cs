namespace StudentPortal.Models.Students
{
    public static class StudentList
    {
        public static List<Student>? StudentsList { get; set; }
    }

    public class Student
    {
        public Guid Id { get; set; } = new Guid();
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Subscribed { get; set; }
    }
}
