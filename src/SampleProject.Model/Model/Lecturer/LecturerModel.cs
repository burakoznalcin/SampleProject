using SampleProject.Model.Model.Base;

namespace SampleProject.Model.Model.Lecturer
{
    public class LecturerModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte IsActive { get; set; }
    }
}
