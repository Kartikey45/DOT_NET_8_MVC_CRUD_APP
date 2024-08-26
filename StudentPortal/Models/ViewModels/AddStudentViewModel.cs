namespace StudentPortal.Models.ViewModels
{
    public class AddStudentViewModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Subscribed { get; set; }
    }
}
