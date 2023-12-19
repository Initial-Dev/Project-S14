using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace S14_API.Models
{

    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string LastName { get; set; }

        [Required]
        [StringLength(45)]
        public string FirstName { get; set; }
        public Gender Gender { get; set; }

        [ForeignKey("AcademicClass")]
        public int AcademicClassId { get; set; }
        public AcademicClass AcademicClass { get; set; }

        public ICollection<Grade> Grades { get; set;}

        [Required]
        [StringLength(92)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }

}
