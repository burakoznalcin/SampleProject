using SampleProject.Model.Entity.Base;
using SampleProject.Model.Entity.Course;
using SampleProject.Model.Entity.Student;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Model.Entity.CourseStudent
{
    public class CourseStudentEntity : BaseEntity
    {
        [Column("course_id")]
        public long CourseId { get; set; }

        [Column("student_id")]
        public long StudentId { get; set; }

        [Column("grade")]
        public int Grade { get; set; }

        [ForeignKey("CourseId")]
        public CourseEntity Course { get; set; }

        [ForeignKey("StudentId")]
        public StudentEntity Student { get; set; }
    }
}
