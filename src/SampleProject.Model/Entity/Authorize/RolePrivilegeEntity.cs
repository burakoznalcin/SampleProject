using SampleProject.Model.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Model.Entity.Authorize
{
    [Table("role_privilege")]
    public class RolePrivilegeEntity : BaseEntity
    {
        [Column("role_id")]
        
        public long RoleId { get; set; }

        [Column("privilege_id")]
        
        public long PrivilegeId { get; set; }

        [ForeignKey("RoleId")]
        public RoleEntity Role { get; set; }

        [ForeignKey("PrivilegeId")]
        public PrivilegeEntity Privilege { get; set; }
    }
}
