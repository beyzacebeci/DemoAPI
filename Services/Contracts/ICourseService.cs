using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses(bool trackChanges);
        Course GetOneCourseById(int id, bool trackChanges);
        Course CreateOneCourse(Course course);
        void UpdateOneCourse(int id, CourseDtoForUpdate courseDto, bool trackChanges);
        void DeleteOneCourse(int id, bool trackChanges);
    }
}
