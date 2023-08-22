using SampleProject.Core.Data.Concretion.EF;
using SampleProject.Data.Context;
using SampleProject.Data.Repository.Abstraction;
using SampleProject.Model.Entity.Course;

namespace SampleProject.Data.Repository.Concretion
{
    public class CourseRepository : EFRepositoryBase<CourseEntity>, ICourseRepository
    {
        public CourseRepository(SampleProjectDbContext sampleProjectDbContext) : base(sampleProjectDbContext)
        {
        }
    }
}
