using SampleProject.Model.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Model.Entity.Authorize
{
    [Table("role")]
    public class RoleEntity : BaseEntity
    {
        
        [Column("name")]
        public string Name { get; set; }
    }
}
