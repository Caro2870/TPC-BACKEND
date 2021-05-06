using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.API.Extensions;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services;
using TPC_UPC.Resources;

namespace TPC_UPC.Controllers
{
    
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LessonTypeController : ControllerBase
    {
        private readonly ILessonTypeService _lessonTypeService;
        private readonly IMapper _mapper;

        public LessonTypeController(ILessonTypeService lessonTypeService, IMapper mapper)
        {
            _lessonTypeService = lessonTypeService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LessonTypeResource>), 200)]
        public async Task<IEnumerable<LessonTypeResource>> GetAllAsync()
        {
            var lessonTypes = await _lessonTypeService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<LessonType>, IEnumerable<LessonTypeResource>>(lessonTypes);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LessonTypeResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _lessonTypeService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var lessonTypeResource = _mapper.Map<LessonType, LessonTypeResource>(result.Resource);
            return Ok(lessonTypeResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(MeetingResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveLessonTypeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var lessonType = _mapper.Map<SaveLessonTypeResource, LessonType>(resource);
            var result = await _lessonTypeService.SaveAsync(lessonType);

            if (!result.Success)
                return BadRequest(result.Message);
            var lessonTypeResource = _mapper.Map<LessonType, LessonTypeResource>(result.Resource);
            return Ok(lessonTypeResource);
        }
    }
}