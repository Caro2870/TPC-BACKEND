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
        private readonly ILessonService _lessonService;

        public LessonStudentController(ILessonStudentService lessonStudentService, IMapper mapper, ILessonService lessonService)
        {
            _lessonStudentService = lessonStudentService;
            _mapper = mapper;
            _lessonService = lessonService;
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
            await _lessonService.UpdateCountAsync(resource.LessonId);
            var nuResource = _mapper.Map<LessonStudent, LessonStudentResource>(result.Resource);
            Console.WriteLine(result.Resource.Lesson.Contador);
            return Ok(nuResource);
        }

        [HttpDelete("/lessons/{lessonId}/students/{studentId}")]
        public async Task<IActionResult> DeleteAsync(int lessonId, int studentId)
        {
            var result = await _lessonStudentService.DeleteAsync(lessonId, studentId);
            if (!result.Success)
                return BadRequest(result.Message);
            var nuResource = _mapper.Map<LessonStudent, LessonStudentResource>(result.Resource);
            return Ok(nuResource);
        }

        [HttpPut("/lessons/{lessonsId}/students/{studentId}")]
        public async Task<IActionResult> PutAsync(int lessonId, int studentId, [FromBody] SaveLessonStudentResource resource)
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
            var lessonStudents = await _lessonStudentService.ListByStudentIdAsync(lessonId);
            var resources = _mapper.Map<IEnumerable<LessonStudent>, IEnumerable<LessonStudentResource>>(lessonStudents);
            return resources;
        }

        //Added by rodrigo rule 6
        [HttpGet("{lessonId}")]
        public async Task<IEnumerable<LessonStudentResource>> GetStudentsAssistantsByLessonIdAsync(int lessonId)
        {
            var lessonStudents = await _lessonStudentService.ListStudentAssistantsByLessonIdAsync(lessonId);
            var resources = _mapper.Map<IEnumerable<LessonStudent>, IEnumerable<LessonStudentResource>>(lessonStudents);
            return resources;
        }
    }
}