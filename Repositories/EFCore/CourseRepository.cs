using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCourse(Course course) => Create(course);

        public void DeleteOneCourse(Course course) => Delete(course);

        public IQueryable<Course> GetAllCourses(bool trackChanges) =>
            FindAll(trackChanges);  

        public Course GetOneCourseById(int id, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefault();

        public void UpdateOneCourse(Course course)=> Update(course);
    }
}
