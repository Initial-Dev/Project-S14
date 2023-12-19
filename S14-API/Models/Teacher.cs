using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S14_API.Models
{
    public class Teacher
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

        public ICollection<Subject> Subjects { get; set; }

        [Required]
        [StringLength(92)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }

}
