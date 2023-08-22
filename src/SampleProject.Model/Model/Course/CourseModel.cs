using SampleProject.Model.Model.Base;

namespace SampleProject.Model.Model.Course
{
    public class CourseModel : BaseModel
    {
        public string Name { get; set; }
        public int Status { get; set; }
        public long LecturerId { get; set; }
        public byte IsActive { get; set; }
    }
}
