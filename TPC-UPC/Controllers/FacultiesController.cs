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
        public async Task<IEnumerable<FacultyResource>> GetAllAsync()
        {
            var faculties = await _facultyService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Faculty>, IEnumerable<FacultyResource>>(faculties);
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(FacultyResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveFacultyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var Faculty = _mapper.Map<SaveFacultyResource, Faculty>(resource);
            var result = await _facultyService.SaveAsync(Faculty);

            if (!result.Success)
                return BadRequest(result.Message);
            var FacultyResource = _mapper.Map<Faculty, FacultyResource>(result.Resource);
            return Ok(FacultyResource);
        }
    }
}