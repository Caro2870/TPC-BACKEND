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
    [Route("/api/faculties/{facultyId}/coordinators")]
    public class FacultyCoordinatorsController : ControllerBase
    {
         private readonly ICoordinatorService _coordinatorService;
        private readonly IMapper _mapper;
        public FacultyCoordinatorsController(ICoordinatorService CoordinatorService, IMapper mapper)
        {
            _coordinatorService = CoordinatorService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all coordinators of a faculty",
            Description = "List of coordinators of a faculty",
            OperationId = "ListAllFacultyCoordinators")]
        [SwaggerResponse(200, "List of coordinators of a faculty", typeof(IEnumerable<CoordinatorResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CoordinatorResource>), 200)]
        public async Task<IEnumerable<CoordinatorResource>> GetAllAsync(int facultyId)
        {
            //var faculties = await _CoordinatorService.ListAsync();
            //var resources = _mapper
            //    .Map<IEnumerable<Coordinator>, IEnumerable<CoordinatorResource>>(faculties);
            //return resources;

            var coordinators = await _coordinatorService.ListByFacultyIdAsync(facultyId);
            var resources = _mapper
                .Map<IEnumerable<Coordinator>, IEnumerable<CoordinatorResource>>(coordinators);
            return resources;
        }
    }
}
