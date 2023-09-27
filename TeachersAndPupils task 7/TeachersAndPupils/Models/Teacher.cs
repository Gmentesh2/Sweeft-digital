using System.ComponentModel.DataAnnotations;

namespace TeachersAndPupils.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Subject { get; set; }
    }
}
