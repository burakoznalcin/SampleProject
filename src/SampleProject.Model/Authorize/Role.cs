using SampleProject.Model.Model.Authorize;

namespace SampleProject.Model.Authorize
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PrivilegeModel> Privileges { get; set; }
    }

}
