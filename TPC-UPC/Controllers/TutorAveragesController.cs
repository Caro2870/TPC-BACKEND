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
    [ApiController]
    [Route("/api/tutors/{tutorId}/{courseId}")]
    public class TutorAveragesController : ControllerBase
    {
        private readonly ITutorService _tutorService;
        private readonly IMapper _mapper;

        public TutorAveragesController(ITutorService tutorService, IMapper mapper)
        {
            _tutorService = tutorService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Returns the average of the califications students gave this tutor for every taught workshop",
            Description = "The average of the califications students gave this tutor for every taught workshop",
            OperationId = "ReturnsTheCalificationAverageGivenInTheWorkshopsOfThisCourse")]
        [SwaggerResponse(200, "The average of the califications students gave this tutor for every taught workshop")]
        [HttpGet("/workshopsAverage")]
        //[ProducesResponseType(typeof(double.IsClass, 200)]
        public double GetWorkshopsAverage(int tutorId, int courseId)
        {
            //var faculties = await _CoordinatorService.ListAsync();
            //var resources = _mapper
            //    .Map<IEnumerable<Coordinator>, IEnumerable<CoordinatorResource>>(faculties);
            //return resources;

            return _tutorService.GetWorkshopsAverage(tutorId, courseId, 2);
        }

        [SwaggerOperation(
            Summary = "Returns the average of the califications students gave this tutor for every taught workshop",
            Description = "The average of the califications students gave this tutor for every taught workshop",
            OperationId = "ReturnsTheCalificationAverageGivenInTheWorkshopsOfThisCourse")]
        [SwaggerResponse(200, "The average of the califications students gave this tutor for every taught workshop")]
        [HttpGet("/tutorshipsAverage")]
        //[ProducesResponseType(typeof(double.IsClass, 200)]
        public double GetTutorshipsAverage(int tutorId, int courseId)
        {
            //var faculties = await _CoordinatorService.ListAsync();
            //var resources = _mapper
            //    .Map<IEnumerable<Coordinator>, IEnumerable<CoordinatorResource>>(faculties);
            //return resources;

            return _tutorService.GetWorkshopsAverage(tutorId, courseId,1);
        }
    }
}
