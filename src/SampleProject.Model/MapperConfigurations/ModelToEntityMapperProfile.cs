using AutoMapper;
using SampleProject.Model.Entity.Authorize;
using SampleProject.Model.Entity.Base;
using SampleProject.Model.Entity.Course;
using SampleProject.Model.Entity.Student;
using SampleProject.Model.Model.Authorize;
using SampleProject.Model.Model.Base;
using SampleProject.Model.Model.Course;
using SampleProject.Model.Model.Student;

namespace SampleProject.Model.MapperConfigurations
{
    public class ModelToEntityMapperProfile : Profile
    {
        public ModelToEntityMapperProfile()
        {
            CreateMap<BaseModel, BaseEntity>();

            CreateMap<StudentModel, StudentEntity>().IncludeBase<BaseModel, BaseEntity>();
            CreateMap<CourseModel, CourseEntity>().IncludeBase<BaseModel, BaseEntity>();


            CreateMap<PersonnelModel, PersonnelEntity>().IncludeBase<BaseModel, BaseEntity>();
            CreateMap<RoleModel, RoleEntity>().IncludeBase<BaseModel, BaseEntity>();
            CreateMap<PersonnelRoleModel, PersonnelRoleEntity>()
                .ForMember(x=> x.Personnel , source => source.Ignore())
                .ForMember(x=> x.Role , source => source.Ignore())
                .IncludeBase<BaseModel, BaseEntity>();

            CreateMap<PrivilegeModel, PrivilegeEntity>().IncludeBase<BaseModel, BaseEntity>();
            CreateMap<RolePrivilegeModel, RolePrivilegeEntity>()
                .ForMember(x => x.RoleId, source => source.MapFrom(src => src.Role.Id))
                .ForMember(x => x.PrivilegeId, source => source.MapFrom(src => src.Privilege.Id))
                .IncludeBase<BaseModel, BaseEntity>();
        }
    }
}
