namespace S14_API.Models.DTO
{
    public class TeacherDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }   
        public Gender Gender { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
