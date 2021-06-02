using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Services;
using TPC_UPC.Resources;
using TPC_UPC.Domain.Models;
using TPC_UPC.API.Extensions;

namespace TPC_UPC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonStudentController : ControllerBase
    {
        private readonly ILessonStudentService  _lessonStudentService;
        private readonly IMapper _mapper;

        public LessonStudentController(ILessonStudentService lessonStudentService, IMapper mapper)
        {
            _lessonStudentService = lessonStudentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveLessonStudentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var nu = _mapper.Map<SaveLessonStudentResource, LessonStudent>(resource);
            var result = await _lessonStudentService.SaveAsync(nu);



            if (!result.Success)
                return BadRequest(result.Message);
            var nuResource = _mapper.Map<LessonStudent, LessonStudentResource>(result.Resource);
            return Ok(nuResource);
        }

        [HttpDelete("/lessons/{lessonId}/students/{studentId}")]
        public async Task<IActionResult> DeleteAsync(int lessonId, int studentId)
        {
            var result = await _lessonStudentService.UnassignLessonStudentAsync(lessonId, studentId);
            if (!result.Success)
                return BadRequest(result.Message);
            var nuResource = _mapper.Map<LessonStudent, LessonStudentResource>(result.Resource);
            return Ok(nuResource);
        }

        [HttpPut("/lessons/{lessonsId}/students/{studentId}")]
        public async Task<IActionResult> UpdateAsync(int lessonId, int studentId, [FromBody] SaveLessonStudentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var nu = _mapper.Map<SaveLessonStudentResource, LessonStudent>(resource);
            var result = await _lessonStudentService.UpdateAsync(lessonId, studentId, nu);

            if (!result.Success)
                return BadRequest(result.Message);
            var nuResource = _mapper.Map<LessonStudent, LessonStudentResource>(result.Resource);
            return Ok(nuResource);
        }

        //Lists
        [HttpGet]
        public async Task<IEnumerable<LessonStudentResource>> GetAllAsync()
        {
            var lessonStudents = await _lessonStudentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<LessonStudent>, IEnumerable<LessonStudentResource>>(lessonStudents);
            return resources;
        }

        [HttpGet("/student/{studentId}")]
        public async Task<IEnumerable<LessonStudentResource>> GetAllByStudentIdAsync(int studentId)
        {
            var lessonStudents = await _lessonStudentService.ListByStudentIdAsync(studentId);
            var resources = _mapper.Map<IEnumerable<LessonStudent>, IEnumerable<LessonStudentResource>>(lessonStudents);
            return resources;
        }

        [HttpGet("/lessons/{lessonId}")]
        public async Task<IEnumerable<LessonStudentResource>> GetAllByLessonIdAsync(int lessonId)
        {
            var lessonStudents = await _lessonStudentService.ListStudentsByLessonIdAsync(lessonId);
            var resources = _mapper.Map<IEnumerable<LessonStudent>, IEnumerable<LessonStudentResource>>(lessonStudents);
            return resources;
        }
    }
}