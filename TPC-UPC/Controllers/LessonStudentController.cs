using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    class LessonStudentController : ControllerBase
    {
        private readonly ILessonStudentService _lessonStudentService;
        private readonly IMapper _mapper;

        public LessonStudentController(ILessonStudentService lessonStudentService, IMapper mapper)
        {
            _lessonStudentService = lessonStudentService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LessonStudentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _lessonStudentService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var lessonStudentResource = _mapper.Map<LessonStudent, LessonStudentResource>(result.Resource);//de Entity a Resource
            return Ok(lessonStudentResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(LessonStudentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveLessonStudentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var lessonStudent = _mapper.Map<SaveLessonStudentResource, LessonStudent>(resource);
            var result = await _lessonStudentService.SaveAsync(lessonStudent);

            if (!result.Success)
                return BadRequest(result.Message);
            var lessonStudentResource = _mapper.Map<LessonStudent, LessonStudentResource>(result.Resource);
            return Ok(lessonStudentResource);
        }
    }
}
