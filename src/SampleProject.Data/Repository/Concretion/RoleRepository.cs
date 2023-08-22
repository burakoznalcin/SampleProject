﻿using SampleProject.Core.Data.Concretion.EF;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Authorize;

namespace SampleProject.Data.Repository.Concretion
{
    public class RoleRepository : EFRepositoryBase<RoleEntity>, IRoleRepository
    {
        public RoleRepository(SampleProjectDbContext sampleProjectDbContext) : base(sampleProjectDbContext)
        {
        }
    }
}
