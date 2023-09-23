using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CourseManager : ICourseService
    {
        private readonly IRepositoryManager _manager;
        private IMapper _mapper;

        public CourseManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IEnumerable<Course> GetAllCourses(bool trackChanges)
        {
            return _manager.Course.GetAllCourses(trackChanges);
        }

        public Course GetOneCourseById(int id, bool trackChanges)
        {
            return _manager.Course.GetOneCourseById(id, trackChanges);
        }

        public Course CreateOneCourse(Course course)
        {
            if(course is null ) throw new ArgumentNullException(nameof(course));
           
            _manager.Course.CreateOneCourse(course);
            _manager.Save();
            return course;
        }

        public void DeleteOneCourse(int id, bool trackChanges)
        {
            var entity = _manager.Course.GetOneCourseById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Course with id :{id} could not found");

            _manager.Course.DeleteOneCourse(entity);
            _manager.Save();
        }

        public void UpdateOneCourse(int id, CourseDtoForUpdate courseDto, bool trackChanges)
        {
            var entity = _manager.Course.GetOneCourseById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Course with id :{id} could not found");

            if(courseDto is null)
                throw new ArgumentNullException(nameof(courseDto));

            entity.Name = courseDto.Name;


            //mapping     
            entity = _mapper.Map<Course>(courseDto);
            
            _manager.Course.Update(entity);
            _manager.Save();

        }
    }
}
