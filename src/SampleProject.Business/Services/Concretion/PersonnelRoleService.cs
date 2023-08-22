using AutoMapper;
using SampleProject.Business.Services.Abstraction;
using SampleProject.Core.Business.Concretion;
using SampleProject.Core.UnitOfWork.Abstraction;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Authorize;
using SampleProject.Model.Model.Authorize;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SampleProject.Business.Services.Concretion
{
    public class PersonnelRoleService : BusinessService<PersonnelRoleEntity, PersonnelRoleModel, IPersonnelRoleRepository, SampleProjectDbContext>, IPersonnelRoleService
    {
        public PersonnelRoleService(IUnitOfWork<SampleProjectDbContext, PersonnelRoleEntity, IPersonnelRoleRepository> uow, IMapper mapper) : base(uow, mapper)
        {
        }
    }
}
