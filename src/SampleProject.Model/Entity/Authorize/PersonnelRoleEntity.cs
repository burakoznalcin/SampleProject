using SampleProject.Model.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Model.Entity.Authorize
{
    [Table("personnel_role")]
    public class PersonnelRoleEntity : BaseEntity
    {
        
        [Column("personnel_id")]
        public long PersonnelId { get; set; }

        
        [Column("role_id")]
        public long RoleId { get; set; }

        [ForeignKey("PersonnelId")]
        public virtual PersonnelEntity Personnel { get; set; }

        [ForeignKey("RoleId")]
        public virtual RoleEntity Role { get; set; }
    }
}
