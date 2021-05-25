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
    public class TrainingsController : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        private readonly IMapper _mapper;

        public TrainingsController(ITrainingService trainingService, IMapper mapper)
        {
            _trainingService = trainingService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all trainings",
            Description = "List of trainings",
            OperationId = "ListAllTrainings")]
        [SwaggerResponse(200, "List of Trainings", typeof(IEnumerable<TrainningResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TrainningResource>), 200)]
        public async Task<IEnumerable<TrainningResource>> GetAllAsync()
        {
            var trainings = await _trainingService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Training>, IEnumerable<TrainningResource>>(trainings);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TrainningResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _trainingService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var trainingResource = _mapper.Map<Training, TrainningResource>(result.Resource);
            return Ok(trainingResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TrainningResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveTrainningResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var training = _mapper.Map<SaveTrainningResource, Training>(resource);
            var result = await _trainingService.SaveAsync(training);

            if (!result.Success)
                return BadRequest(result.Message);
            var trainingResource = _mapper.Map<Training, TrainningResource>(result.Resource);
            return Ok(trainingResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TrainningResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTrainningResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var training = _mapper.Map<SaveTrainningResource, Training>(resource);
            var result = await _trainingService.UpdateAsync(id, training);

            if (!result.Success)
                return BadRequest(result.Message);

            var trainingResource = _mapper.Map<Training, TrainningResource>(result.Resource);
            return Ok(trainingResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TrainningResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _trainingService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var trainingResource = _mapper.Map<Training, TrainningResource>(result.Resource);
            return Ok(trainingResource);
        }
    }
}
