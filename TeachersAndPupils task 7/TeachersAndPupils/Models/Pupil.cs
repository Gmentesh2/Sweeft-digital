using System.ComponentModel.DataAnnotations;

namespace TeachersAndPupils.Models
{
    public class Pupil
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
        [MaxLength(30)]
        public string? Class { get; set; }
    }
}
