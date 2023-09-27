using Microsoft.EntityFrameworkCore;
using TeachersAndPupils.Models;

namespace TeachersAndPupils
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                    new Teacher
                    {
                        Id = 1,
                        FirstName = "გიორგი",
                        LastName = "გიორგაძე",
                        Gender = 'M',
                        Subject = "ბიოლოგია"
                    },
                    new Teacher
                    {
                        Id = 2,
                        FirstName = "ზურაბ",
                        LastName = "ზურაბიანი",
                        Gender = 'M',
                        Subject = "მათემატიკა"
                    }
                );

            modelBuilder.Entity<Pupil>().HasData(
                    new Pupil
                    {
                        Id = 1,
                        FirstName = "დავით",
                        LastName = "დავითაშვილი",
                        Gender = 'M',
                        Class = "30-A"
                    },
                    new Pupil
                    {
                        Id = 2,
                        FirstName = "ელენე",
                        LastName = "ელენიძე",
                        Gender = 'F',
                        Class = "30-B"
                    },
                    new Pupil
                    {
                        Id = 3,
                        FirstName = "ანა",
                        LastName = "ანანიაშვილი",
                        Gender = 'F',
                        Class = "30-A"
                    },
                    new Pupil
                    {
                        Id = 4,
                        FirstName = "გიორგი",
                        LastName = "ჩხარტიშვილი",
                        Gender = 'M',
                        Class = "30-B"
                    }
                );

            modelBuilder.Entity<TeacherPupil>().HasKey(tp => new { tp.TeacherId, tp.PupilId });

            modelBuilder.Entity<TeacherPupil>().HasData(
                    new TeacherPupil() { TeacherId = 1, PupilId = 1 },
                    new TeacherPupil() { TeacherId = 1, PupilId = 2 },
                    new TeacherPupil() { TeacherId = 2, PupilId = 3 },
                    new TeacherPupil() { TeacherId = 1, PupilId = 4 }
                );
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<TeacherPupil> TeacherPupils { get; set; }
    }
}
