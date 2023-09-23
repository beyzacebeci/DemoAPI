using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        IQueryable<Course> GetAllCourses(bool trackChanges);
        Course GetOneCourseById(int id, bool trackChanges);
        void CreateOneCourse(Course course);
        void UpdateOneCourse(Course course);
        void DeleteOneCourse(Course course);

    }
}
