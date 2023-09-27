using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersAndPupils.Models
{
    public class TeacherPupil
    {
        [ForeignKey("TeacherId")]
        public Teacher? Teacher { get; set; }
        [Required]
        public int TeacherId { get; set; }

        [ForeignKey("PupilId")]
        public Pupil? Pupil { get; set; }
        [Required]
        public int PupilId { get; set; }
    }
}
