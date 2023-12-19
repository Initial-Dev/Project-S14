namespace S14_BlazorUI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Gender { get; set; }
        public int AcademicClassId { get; set; }
        public AcademicClass AcademicClass { get; set; }

        public List<Grade> Grades { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }

    }

}
