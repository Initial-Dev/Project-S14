using System.Reflection;

namespace S14_API.Models
{

    public class Student
    {
        public int Id { get; set; }
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public Gender Gender { get; set; }

        public int AcademicClassId { get; set; }
        public required AcademicClass AcademicClass { get; set; }

        public required string Username { get; set; }
        public required string Password { get; set; }
    }

}
