using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using TPC_UPC.Domain.Services;
using TPC_UPC.Resources;
using TPC_UPC.Domain.Models;
using TPC_UPC.API.Extensions;


namespace TPC_UPC.Controllers
{
    [Route("/api/[controller]")]
    //el formato, devuelve en .json
    [Produces("application/json")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all courses",
            Description = "List of courses",
            OperationId = "ListAllCourses")]
        [SwaggerResponse(200, "List of Courses", typeof(IEnumerable<CourseResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseResource>), 200)]
        public async Task<IEnumerable<CourseResource>> GetAllAsync()
        {
            var courses = await _courseService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Course>, IEnumerable<CourseResource>>(courses);
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CourseResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveCourseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var course = _mapper.Map<SaveCourseResource, Course>(resource);
            var result = await _courseService.SaveAsync(course);

            if (!result.Success)
                return BadRequest(result.Message);
            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            return Ok(courseResource);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CourseResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _courseService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            return Ok(courseResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CourseResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCourseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var Course = _mapper.Map<SaveCourseResource, Course>(resource);
            var result = await _courseService.UpdateAsync(id, Course);

            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            return Ok(courseResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CourseResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _courseService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource);
            return Ok(courseResource);
        }
    }
}
