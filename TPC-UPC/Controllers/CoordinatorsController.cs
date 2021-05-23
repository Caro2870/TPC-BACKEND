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
    [Route("/api/universities/{universityId}/[controller]")]
    //el formato, devuelve en .json
    [Produces("application/json")]
    [ApiController]
    public class CoordinatorsController : ControllerBase
    {
        private readonly ICoordinatorService _coordinatorService;
        private readonly IMapper _mapper;
        public CoordinatorsController(ICoordinatorService coordinatorService, IMapper mapper)
        {
            _coordinatorService = coordinatorService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all coordinators",
            Description = "List of coordinators",
            OperationId = "ListAllCoordinators")]
        [SwaggerResponse(200, "List of coordinators", typeof(IEnumerable<CoordinatorResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CoordinatorResource>), 200)]
        public async Task<IEnumerable<CoordinatorResource>> GetAllAsync()
        {
            //var coordinators = await _coordinatorService.ListAsync();
            //var resources = _mapper
            //    .Map<IEnumerable<Coordinator>, IEnumerable<CoordinatorResource>>(coordinators);
            //return resources;

            var faculties = await _coordinatorService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Coordinator>, IEnumerable<CoordinatorResource>>(faculties);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CoordinatorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _coordinatorService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var coordinatorResource = _mapper.Map<Coordinator, CoordinatorResource>(result.Resource);
            return Ok(coordinatorResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CoordinatorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaceCoordinatorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var coordinator = _mapper.Map<SaceCoordinatorResource, Coordinator>(resource);
            var result = await _coordinatorService.SaveAsync(coordinator);

            if (!result.Success)
                return BadRequest(result.Message);
            var coordinatorResource = _mapper.Map<Coordinator, CoordinatorResource>(result.Resource);
            return Ok(coordinatorResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CoordinatorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaceCoordinatorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var Coordinator = _mapper.Map<SaceCoordinatorResource, Coordinator>(resource);
            var result = await _coordinatorService.UpdateASync(id, Coordinator);

            if (!result.Success)
                return BadRequest(result.Message);

            var coordinatorResource = _mapper.Map<Coordinator, CoordinatorResource>(result.Resource);
            return Ok(coordinatorResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CoordinatorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _coordinatorService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var coordinatorResource = _mapper.Map<Coordinator, CoordinatorResource>(result.Resource);
            return Ok(coordinatorResource);
        }
    }
}