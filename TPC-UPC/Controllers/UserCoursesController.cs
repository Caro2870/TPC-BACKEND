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
//una cosita
namespace TPC_UPC.Controllers
{
    [ApiController]
    [Route("/api/users/{userId}/courses")]
    public class UserCoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IUserCourseService _userCourseService;
        private readonly IMapper _mapper;

        public UserCoursesController(ICourseService courseService, IUserCourseService userCourseService, IMapper mapper)
        {
            _courseService = courseService;
            _userCourseService = userCourseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseResource>> GetAllByUserIdAsync(int userId)
        {
            var courses = await _courseService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseResource>>(courses);
            return resources;
        }

        [HttpPost("{courseId}")]
        public async Task<IActionResult> AssignUserCourse(int userId, int courseId)
        {
            var result = await _userCourseService.AssignUserCourseAsync(userId, courseId);
            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource.Course);
            return Ok(courseResource);

        }

        [HttpDelete("{CourseId}")]
        public async Task<IActionResult> UnassignUserCourse(int userId, int CourseId)
        {
            var result = await _userCourseService.UnassignUserCourseAsync(userId, CourseId);
            if (!result.Success)
                return BadRequest(result.Message);

            var courseResource = _mapper.Map<Course, CourseResource>(result.Resource.Course);
            return Ok(courseResource);
        }
    }
}
