using Microsoft.EntityFrameworkCore;
using SampleProject.Model.Entity.Authorize;
using SampleProject.Model.Entity.Course;
using SampleProject.Model.Entity.CourseStudent;
using SampleProject.Model.Entity.Lecturer;
using SampleProject.Model.Entity.Student;

namespace SampleProject.Data.Context
{
    public class SampleProjectDbContext : DbContext
    {
        public SampleProjectDbContext(DbContextOptions<SampleProjectDbContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<CourseStudentEntity> CourseStudentEntities { get; set; }
        public DbSet<LecturerEntity> LecturerEntities { get; set; }
        public DbSet<StudentEntity> StudentEntities { get; set; }
        public DbSet<CourseEntity> CourseEntities { get; set; }
        public DbSet<PersonnelEntity> PersonnelEntities { get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<RolePrivilegeEntity> RolePrivilegeEntities { get; set; }
        public DbSet<PrivilegeEntity> PrivilegeEntities { get; set; }
        public DbSet<PersonnelRoleEntity> PersonnelRoleEntities { get; set; }
    }
}
