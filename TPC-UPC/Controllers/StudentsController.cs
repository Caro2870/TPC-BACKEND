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
    [Produces("application/json")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all students",
            Description = "List of students",
            OperationId = "ListAllStudents")]
        [SwaggerResponse(200, "List of students", typeof(IEnumerable<StudentResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentResource>), 200)]
        public async Task<IEnumerable<StudentResource>> GetAllAsync()
        {
            var careears = await _studentService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Student>, IEnumerable<StudentResource>>(careears);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _studentService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var studentResource = _mapper.Map<Student, StudentResource>(result.Resource);
            return Ok(studentResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(StudentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveStudentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var student = _mapper.Map<SaveStudentResource, Student>(resource);
            var result = await _studentService.SaveAsync(student);

            if (!result.Success)
                return BadRequest(result.Message);
            var studentResource = _mapper.Map<Student, StudentResource>(result.Resource);
            return Ok(studentResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(StudentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveStudentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var Student = _mapper.Map<SaveStudentResource, Student>(resource);
            var result = await _studentService.UpdateASync(id, Student);

            if (!result.Success)
                return BadRequest(result.Message);

            var studentResource = _mapper.Map<Student, StudentResource>(result.Resource);
            return Ok(studentResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(StudentResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _studentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var studentResource = _mapper.Map<Student, StudentResource>(result.Resource);
            return Ok(studentResource);
        }
    }
}