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
    [Route("/api/coordinators/{coordinatorId}/trainings")]
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
        [SwaggerResponse(200, "List of Trainings", typeof(IEnumerable<TrainingResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TrainingResource>), 200)]
        public async Task<IEnumerable<TrainingResource>> GetAllByCoordinatorIdAsync(int coordinatorId)
        {
            var trainings = await _trainingService.ListByCoordinatorIdAsync(coordinatorId);
            var resources = _mapper
                .Map<IEnumerable<Training>, IEnumerable<TrainingResource>>(trainings);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TrainingResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _trainingService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var trainingResource = _mapper.Map<Training, TrainingResource>(result.Resource);
            return Ok(trainingResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TrainingResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveTrainningResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var training = _mapper.Map<SaveTrainningResource, Training>(resource);
            var result = await _trainingService.SaveAsync(training);

            if (!result.Success)
                return BadRequest(result.Message);
            var trainingResource = _mapper.Map<Training, TrainingResource>(result.Resource);
            return Ok(trainingResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TrainingResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTrainningResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var training = _mapper.Map<SaveTrainningResource, Training>(resource);
            var result = await _trainingService.UpdateAsync(id, training);

            if (!result.Success)
                return BadRequest(result.Message);

            var trainingResource = _mapper.Map<Training, TrainingResource>(result.Resource);
            return Ok(trainingResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TrainingResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _trainingService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var trainingResource = _mapper.Map<Training, TrainingResource>(result.Resource);
            return Ok(trainingResource);
        }
    }
}
