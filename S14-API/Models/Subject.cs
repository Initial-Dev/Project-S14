using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S14_API.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public required string Name { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public required Teacher Teacher { get; set; }
    }

}
