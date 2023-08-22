using SampleProject.Model.Model.Base;

namespace SampleProject.Model.Model.Authorize
{
    public class PersonnelRoleModel : BaseModel
    {
        public PersonnelModel Personnel { get; set; }
        public RoleModel Role { get; set; }
    }
}
