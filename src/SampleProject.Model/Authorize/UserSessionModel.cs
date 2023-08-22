using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Model.Authorize
{
    public class UserSessionModel
    {
        public long PersonnelId { get; set; }
        public string Username { get; set; }
        public List<Role> Roles { get; set; }
    }
}
