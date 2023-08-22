using SampleProject.Model.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Model.Entity.Authorize
{
    [Table("privilege")]
    public class PrivilegeEntity : BaseEntity
    {
        [Column("name")]
        
        public string Name { get; set; }
    }
}
