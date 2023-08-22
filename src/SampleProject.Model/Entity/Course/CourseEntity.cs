using SampleProject.Model.Entity.Base;
using SampleProject.Model.Entity.Lecturer;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Model.Entity.Course
{
    [Table("course")]
    public class CourseEntity : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("lecturer_id")]
        public long LecturerId { get; set; }

        [Column("is_active")]
        public byte IsActive { get; set; }

        [ForeignKey("LecturerId")]
        public LecturerEntity Lecturer { get; set; }
    }
}
