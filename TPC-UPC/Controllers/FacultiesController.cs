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
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultyService _facultyService;
        private readonly IMapper _mapper;
        public FacultiesController(IFacultyService facultyService, IMapper mapper)
        {
            _facultyService = facultyService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all faculties",
            Description = "List of faculties",
            OperationId = "ListAllfaculties")]
        [SwaggerResponse(200, "List of faculties", typeof(IEnumerable<FacultyResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FacultyResource>), 200)]
        public async Task<IEnumerable<FacultyResource>> GetAllAsync(int universityId)
        {
            //var faculties = await _facultyService.ListAsync();
            //var resources = _mapper
            //    .Map<IEnumerable<Faculty>, IEnumerable<FacultyResource>>(faculties);
            //return resources;

            var faculties = await _facultyService.ListByUniversityIdAsync(universityId);
            var resources = _mapper
                .Map<IEnumerable<Faculty>, IEnumerable<FacultyResource>>(faculties);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FacultyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _facultyService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var FacultyResource = _mapper.Map<Faculty, FacultyResource>(result.Resource);
            return Ok(FacultyResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FacultyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
<<<<<<< HEAD
        public async Task<IActionResult> PostAsync([FromBody] SaveFacultyResource resource, int universityId)
=======
        public async Task<IActionResult> PostAsync([FromBody] SaveFacultyResource resource, int universityId )
>>>>>>> master
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var faculty = _mapper.Map<SaveFacultyResource, Faculty>(resource);
            var result = await _facultyService.SaveAsync(faculty, universityId);

            if (!result.Success)
                return BadRequest(result.Message);
            var facultyResource = _mapper.Map<Faculty, FacultyResource>(result.Resource);
            return Ok(facultyResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FacultyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFacultyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var faculty = _mapper.Map<SaveFacultyResource, Faculty>(resource);
            var result = await _facultyService.UpdateASync(id, faculty);

            if (!result.Success)
                return BadRequest(result.Message);

            var facultyResource = _mapper.Map<Faculty, FacultyResource>(result.Resource);
            return Ok(facultyResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FacultyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _facultyService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var facultyResource = _mapper.Map<Faculty, FacultyResource>(result.Resource);
            return Ok(facultyResource);
        }
    }
}