using SampleProject.Model.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Model.Entity.Lecturer
{
    public class LecturerEntity: BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("is_active")]
        public byte IsActive { get; set; }
    }
}
