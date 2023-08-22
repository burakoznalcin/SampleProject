using SampleProject.Model.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Model.Entity.Student
{
    [Table("student")]
    public class StudentEntity : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("middle_name")]
        public string MiddleName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }
    }
}
