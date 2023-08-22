using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleProject.Business.Services.Abstraction;
using SampleProject.Business.Services.Concretion;
using SampleProject.Business.Utilities.AuthorizeHelpers;
using SampleProject.Business.Utilities.Session;
using SampleProject.Core.Data.Abstraction;
using SampleProject.Core.UnitOfWork.Abstraction;
using SampleProject.Core.UnitOfWork.Concretion;
using SampleProject.Core.Utilities.AppSettings;
using SampleProject.Data.Repository.Concretion;
using SampleProject.Model.Entity.Authorize;
using SampleProject.Model.Entity.Course;
using SampleProject.Model.Entity.Student;
using SampleProject.Model.MapperConfigurations;
using System;

namespace SampleProject.Business.DependencyContainer
{
    public static class ConfigureContainerExtensions
    {
        public static IServiceCollection AddContainerServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IPersonnelService, PersonnelService>();
            services.AddScoped<IPersonnelRoleService, PersonnelRoleService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRolePrivilegeService, RolePrivilegeService>();
            services.AddScoped<IPrivilegeService, PrivilegeService>();
            services.AddScoped<IAuthorizeService, AuthorizeService>();

            services.AddScoped(typeof(IRepositoryBase<StudentEntity>), typeof(StudentRepository));
            services.AddScoped(typeof(IRepositoryBase<CourseEntity>), typeof(CourseRepository));
            services.AddScoped(typeof(IRepositoryBase<PersonnelEntity>), typeof(PersonnelRepository));
            services.AddScoped(typeof(IRepositoryBase<PersonnelRoleEntity>), typeof(PersonnelRoleRepository));
            services.AddScoped(typeof(IRepositoryBase<RoleEntity>), typeof(RoleRepository));
            services.AddScoped(typeof(IRepositoryBase<RolePrivilegeEntity>), typeof(RolePrivilegeRepository));
            services.AddScoped(typeof(IRepositoryBase<PrivilegeEntity>), typeof(PrivilegeRepository));

            services.AddAutoMapper(typeof(EntityToModelMapperProfile));
            services.AddAutoMapper(typeof(ModelToEntityMapperProfile));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            IConfigurationSection? sampleSection = configuration.GetSection("SampleSettings");

            services.Configure<SampleSettings>(configuration.GetSection("SampleSettings"));

            services.AddScoped(typeof(IUnitOfWork<,,>), typeof(UnitOfWork<,,>));

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped<SessionManager>();

            services.AddOptions();

            services.AddScoped(typeof(TokenHelper));       

            return services;
        }
    }
}
