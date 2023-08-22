using SampleProject.Model.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Model.Model.CourseStudent
{
    public class CourseStudentModel :BaseModel
    {
        public long CourseId { get; set; }
        public int StudentId { get; set; }
        public int Grade { get; set; }
    }
}
