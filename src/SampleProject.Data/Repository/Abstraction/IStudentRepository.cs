using SampleProject.Core.Data.Abstraction;
using SampleProject.Model.Entity.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Data.Repository.Abstraction
{
    public interface IStudentRepository : IRepositoryBase<StudentEntity>
    {
    }
}
