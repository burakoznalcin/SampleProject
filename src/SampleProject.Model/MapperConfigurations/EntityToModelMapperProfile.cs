using AutoMapper;
using SampleProject.Model.Entity.Authorize;
using SampleProject.Model.Entity.Base;
using SampleProject.Model.Entity.Course;
using SampleProject.Model.Entity.Student;
using SampleProject.Model.Model.Authorize;
using SampleProject.Model.Model.Base;
using SampleProject.Model.Model.Course;
using SampleProject.Model.Model.Student;
using System.Runtime.ConstrainedExecution;

namespace SampleProject.Model.MapperConfigurations
{
    public class EntityToModelMapperProfile : Profile
    {
        public EntityToModelMapperProfile()
        {
            CreateMap<BaseEntity, BaseModel>();

            CreateMap<StudentEntity, StudentModel>().IncludeBase<BaseEntity,BaseModel>();
            CreateMap<CourseEntity, CourseModel>().IncludeBase<BaseEntity,BaseModel>();

            CreateMap<PersonnelEntity,PersonnelModel>().IncludeBase<BaseEntity, BaseModel>();
            CreateMap<RoleEntity, RoleModel>().IncludeBase<BaseEntity, BaseModel>();
            CreateMap<PersonnelRoleEntity, PersonnelRoleModel>().IncludeBase<BaseEntity, BaseModel>();
            CreateMap<PrivilegeEntity,PrivilegeModel>().IncludeBase<BaseEntity, BaseModel>();
            CreateMap<RolePrivilegeEntity, RolePrivilegeModel>().IncludeBase<BaseEntity, BaseModel>();
        }
    }
}
