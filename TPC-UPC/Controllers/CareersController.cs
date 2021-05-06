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
    public class CareersController : ControllerBase
    {
        private readonly ICareerService _careerService;
        private readonly IMapper _mapper;
        public CareersController(ICareerService careerService, IMapper mapper)
        {
            _careerService = careerService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all careers",
            Description = "List of careers",
            OperationId = "ListAllCareers")]
        [SwaggerResponse(200, "List of careers", typeof(IEnumerable<CareerResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CareerResource>), 200)]
        public async Task<IEnumerable<CareerResource>> GetAllAsync()
        {
            var careers = await _careerService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Career>, IEnumerable<CareerResource>>(careers);
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CareerResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveCareerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var Career = _mapper.Map<SaveCareerResource, Career>(resource);
            var result = await _careerService.SaveAsync(Career);

            if (!result.Success)
                return BadRequest(result.Message);
            var CareerResource = _mapper.Map<Career, CareerResource>(result.Resource);
            return Ok(CareerResource);
        }
    }
}