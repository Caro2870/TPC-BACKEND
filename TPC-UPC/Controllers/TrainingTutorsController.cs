using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services;
using TPC_UPC.Resources;

namespace TPC_UPC.Controllers
{
    [Route("api/trainings/{trainingId}/tutors")]
    [ApiController]
    public class TrainingTutorsController : ControllerBase
    {
        private readonly ITrainingTutorService _trainingTutorService;
        private readonly IMapper _mapper;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TrainningTutorResource>), 200)]
        public async Task<IEnumerable<TrainningTutorResource>> GetAllAsync()
        {
            var trainingTutors = await _trainingTutorService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<TrainingTutor>, IEnumerable<TrainningTutorResource>>(trainingTutors);
            return resources;
        }
    }
}
