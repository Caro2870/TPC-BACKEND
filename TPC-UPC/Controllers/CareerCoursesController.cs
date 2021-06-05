using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Services;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using TPC_UPC.Resources;
using TPC_UPC.Domain.Models;
using TPC_UPC.API.Extensions;

namespace TPC_UPC.Controllers
{
    [ApiController]
    [Route("/api/careers/{careerId}/courses")]
    public class CareerCoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ICareerCourseService _careerCourseService;
        private readonly IMapper _mapper;

        public CareerCoursesController(ICourseService courseService, ICareerCourseService careerCourseService, IMapper mapper)
        {
            _courseService = courseService;
            _careerCourseService = careerCourseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseResource>> GetAllByCareerIdAsync(int careerId)
        {
            var courses = await _courseService.ListByCareerIdAsync(careerId);
            var resources = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseResource>>(courses);
            return resources;
        }

        [HttpPost("{courseId}")]
        public async Task<IActionResult> AssignCareerCourse(int careerId, int courseId)
        {
            var result = await _careerCourseService.AssignCareerCourseAsync(careerId, courseId);
            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource.Course);
            return Ok(courseResource);

        }

        [HttpDelete("{CourseId}")]
        public async Task<IActionResult> UnassignCareerCourse(int careerId, int CourseId)
        {
            var result = await _careerCourseService.UnassignCareerCourseAsync(careerId, CourseId);
            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource.Course);
            return Ok(courseResource);
        }
    }
}