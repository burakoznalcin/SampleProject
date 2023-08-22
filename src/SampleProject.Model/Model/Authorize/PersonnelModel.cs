using SampleProject.Model.Model.Base;

namespace SampleProject.Model.Model.Authorize
{
    public class PersonnelModel : BaseModel
    {
        public string UserName { get; set; }

        public int Status { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string PasswordAgain { get; set; }
    }
}
