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
using TPC_UPC.Extensions;

namespace TPC_UPC.Controllers{
    [Route("/api/[controller]")]
    //el formato, devuelve en .json
    [Produces("application/json")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversityService _universityService;
        private readonly IMapper _mapper;
        public UniversitiesController(IUniversityService universityService, IMapper mapper)
        {
            _universityService = universityService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all universities",
            Description = "List of Universities",
            OperationId = "ListAllUniversities")]
        [SwaggerResponse(200, "List of Universities", typeof(IEnumerable<UniversityResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UniversityResource>), 200)]
        public async Task<IEnumerable<UniversityResource>> GetAllAsync()
        {
            var universities = await _universityService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<University>, IEnumerable<UniversityResource>>(universities);
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UniversityResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveUniversityResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var university = _mapper.Map<SaveUniversityResource, University>(resource);
            var result = await _universityService.SaveAsync(university);

            if (!result.Success)
                return BadRequest(result.Message);
            var universityResource = _mapper.Map<University, UniversityResource>(result.Resource);
            return Ok(universityResource);
        }
    }



}