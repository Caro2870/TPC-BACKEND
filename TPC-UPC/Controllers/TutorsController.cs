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
    public class TutorsController : ControllerBase
    {
        private readonly ITutorService _tutorService;
        private readonly IMapper _mapper;
        public TutorsController(ITutorService tutorService, IMapper mapper)
        {
            _tutorService = tutorService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all tutors",
            Description = "List of tutors",
            OperationId = "ListAllTutors")]
        [SwaggerResponse(200, "List of Tutors", typeof(IEnumerable<TutorResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TutorResource>), 200)]
        public async Task<IEnumerable<TutorResource>> GetAllAsync()
        {
            var tutors = await _tutorService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Tutor>, IEnumerable<TutorResource>>(tutors);
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TutorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveTutorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var tutor = _mapper.Map<SaveTutorResource, Tutor>(resource);
            var result = await _tutorService.SaveAsync(tutor);

            if (!result.Success)
                return BadRequest(result.Message);
            var tutorResource = _mapper.Map<Tutor, TutorResource>(result.Resource);
            return Ok(tutorResource);
        }
    }
}