namespace S14_API.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public Gender Gender { get; set; }

        public required string Username { get; set; }
        public required string Password { get; set; }
    }

}
