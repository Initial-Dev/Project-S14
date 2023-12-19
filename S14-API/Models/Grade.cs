using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S14_API.Models
{
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Range(0, 20)]
        public int Value { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public required Student Student { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public required Teacher Teacher { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public required Subject Subject { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }

}
