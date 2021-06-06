using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.API.Extensions;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services;
using TPC_UPC.Resources;

namespace TPC_UPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingTutorsController : ControllerBase
    {
        private readonly ITrainingTutorService _trainingTutorService;
        private readonly IMapper _mapper;

        public TrainingTutorsController(ITrainingTutorService trainingTutorService, IMapper mapper)
        {
            _trainingTutorService = trainingTutorService;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TrainingTutorResource>), 200)]
        public async Task<IEnumerable<TrainingTutorResource>> GetAllAsync()
        {
            var trainingTutors = await _trainingTutorService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<TrainingTutor>, IEnumerable<TrainingTutorResource>>(trainingTutors);
            return resources;
        }

        [HttpGet("/trainings/{trainingId}")]
        public async Task<IEnumerable<TrainingTutorResource>> GetAllByTrainingIdAsync(int trainingId)
        {
            var trainingTutors = await _trainingTutorService.ListByTrainingIdAsync(trainingId);
            var resources = _mapper
                .Map<IEnumerable<TrainingTutor>, IEnumerable<TrainingTutorResource>>(trainingTutors);
            return resources;
        }

        [HttpGet("/tutors/{tutorId}")]
        public async Task<IEnumerable<TrainingTutorResource>> GetAllbyTutorIdAsync(int tutorId)
        {
            var trainingTutors = await _trainingTutorService.ListByTutorIdAsync(tutorId);
            var resources = _mapper
                .Map<IEnumerable<TrainingTutor>, IEnumerable<TrainingTutorResource>>(trainingTutors);
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TrainingTutorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveTrainingTutorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var trainingTutor = _mapper.Map<SaveTrainingTutorResource, TrainingTutor>(resource);
            var result = await _trainingTutorService.SaveAsync(trainingTutor);

            if (!result.Success)
                return BadRequest(result.Message);
            var trainingTutorResource = _mapper.Map<TrainingTutor, TrainingTutorResource>(result.Resource);
            return Ok(trainingTutorResource);
        }

        [HttpPut("/trainings/{trainingId}/tutors/{tutorId}")]
        [ProducesResponseType(typeof(TrainingTutorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int trainingId, int tutorId, [FromBody] SaveTrainingTutorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var trainingTutor = _mapper.Map<SaveTrainingTutorResource, TrainingTutor>(resource);
            var result = await _trainingTutorService.UpdateAsync(trainingId, tutorId, trainingTutor);

            if (!result.Success)
                return BadRequest(result.Message);
            var trainingTutorResource = _mapper.Map<TrainingTutor, TrainingTutorResource>(result.Resource);
            return Ok(trainingTutorResource);
        }

        [HttpDelete("/trainings/{trainingId}/tutors/{tutorId}")]
        [ProducesResponseType(typeof(TrainingTutorResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int trainingId, int tutorId)
        {
            var result = await _trainingTutorService.DeleteAsync(trainingId, tutorId);
            if (!result.Success)
                return BadRequest(result.Message);
            var trainingTutorResource = _mapper.Map<TrainingTutor, TrainingTutorResource>(result.Resource);
            return Ok(trainingTutorResource);
        }
    }
}
