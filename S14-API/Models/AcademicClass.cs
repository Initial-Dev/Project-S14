using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S14_API.Models
{
    public class AcademicClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Level { get; set; }

        [ForeignKey("Teacher")]
        public int HeadTeacherId { get; set; }
        public Teacher HeadTeacher { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
