using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace SampleProject.Model.Entity.Base
{
    public class BaseEntity
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
