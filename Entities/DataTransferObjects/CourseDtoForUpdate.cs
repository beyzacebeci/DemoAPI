using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record CourseDtoForUpdate
    {
        public int Id { get; init; } 
        public String Name { get; init; }
    }
}
