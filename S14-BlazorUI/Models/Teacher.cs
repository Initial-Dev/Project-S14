namespace S14_BlazorUI.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Gender { get; set; }

        public SubjectContainer Subjects { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }
    }

}
