using SampleProject.Model.Model.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Model.Authorize
{
    public class TokenModel
    {
        public long PersonnelId { get; set; }
        public string Username { get; set; }
        public string RefreshToken { get; set; }
        public string RefreshTokenEndDate { get; set; }
        public string ValidTo { get; set; }
        public List<Role> Roles { get; set; }
    }

}
