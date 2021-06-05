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
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonController(ILessonService lessonService, IMapper mapper)
        {
            _lessonService = lessonService;
            _mapper = mapper;
        }


        [SwaggerOperation(
            Summary = "List all Lessons",
            Description = "List of Lessons",
            OperationId = "ListAllLessons")]
        [ProducesResponseType(typeof(AccountResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        [HttpGet]
        public async Task<IEnumerable<LessonResource>> GetAllAsync()
        {
            var lessons = await _lessonService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Lesson>, IEnumerable<LessonResource>>(lessons);
            return resources;
        }

        [HttpGet("{lessonId}")]
        [ProducesResponseType(typeof(LessonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int lessonId)
        {
            var result = await _lessonService.GetByIdAsync(lessonId);
            if (!result.Success)
                return BadRequest(result.Message);
            var lessonResource = _mapper
                .Map<Lesson, LessonResource>(result.Resource);//de Entity a Resource
            return Ok(lessonResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(LessonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveLessonResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var lesson = _mapper.Map<SaveLessonResource, Lesson>(resource);
            var result = await _lessonService.SaveAsync(lesson);

            if (!result.Success)
                return BadRequest(result.Message);
            var lessonResource = _mapper.Map<Lesson, LessonResource>(result.Resource);
            return Ok(lessonResource);
        }


        [SwaggerOperation(
            Summary = "Delete Lesson",
            Description = "Delete Lesson by Id",
            OperationId = "DeleteLesson")]
        [HttpDelete("{accountId}")]
        [ProducesResponseType(typeof(LessonResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int lessonId)
        {
            var result = await _lessonService.DeleteAsync(lessonId);
            if (!result.Success)
                return BadRequest(result.Message);
            var lessonResource = _mapper.Map<Lesson, LessonResource>(result.Resource);
            return Ok(lessonResource);
        }
    }
}