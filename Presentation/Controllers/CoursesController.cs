using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController :ControllerBase
    {
            private readonly IServiceManager _manager;

            public CoursesController(IServiceManager manager)
            {
                _manager = manager;
            }

            [Authorize(Roles ="User,Editor,Admin")]
            [HttpGet]
            public IActionResult GetAllCourses()
            {
                try
                {
                    var courses = _manager.CourseService.GetAllCourses(false);
                    return Ok(courses);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }

            }

            [Authorize(Roles ="Editor,Admin")]
            [HttpGet("{id:int}")]
            public IActionResult GetOneCourse([FromRoute(Name = "id")] int id)
            {
                try
                {
                    var course = _manager
                        .CourseService
                        .GetOneCourseById(id, true);

                    if (course is null)
                        return NotFound(); //404

                    return Ok(course);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }



            }
           
            [Authorize(Roles ="Admin")]
            [HttpPost]
            public IActionResult CreateOneBook([FromBody] Course course)
            {
                try
                {
                    if (course is null)
                        return BadRequest(); //400
                    _manager.CourseService.CreateOneCourse(course);
             
                    return StatusCode(201, course);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPut("{id:int}")]
            public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,
               [FromBody] CourseDtoForUpdate courseDto)
            {
                try
                {
                    if (courseDto is null)
                        return BadRequest(); // 400 

                    _manager.CourseService.UpdateOneCourse(id,  courseDto, true);
                    return NoContent(); // 204
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }




    }
}
