using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Model.Model.Base
{
    public class BaseModel
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
