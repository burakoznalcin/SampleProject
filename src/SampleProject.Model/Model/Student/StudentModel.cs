using SampleProject.Model.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Model.Model.Student
{
    public class StudentModel : BaseModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
