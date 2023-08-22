using SampleProject.Model.Entity.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleProject.Model.Entity.Authorize
{
    [Table("personnel")]
    public class PersonnelEntity : BaseEntity
    {
        [Column("username")]
        public string UserName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("status")]
        public int Status { get; set; } = 0;

        [Column("first_name")]
        public string? FirstName { get; set; }

        [Column("last_name")]
        public string? LastName { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("number_of_incorrect_entries")]
        public int NumberOfIncorrectEntries { get; set; } = 0;

        [Column("password_change_date")]
        public DateTime PasswordChangeDate { get; set; } = DateTime.Now;
    }
}
