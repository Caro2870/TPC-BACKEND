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
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;
        private readonly IMapper _mapper;

        public MeetingController(IMeetingService meetingService, IMapper mapper)
        {
            _meetingService = meetingService;
            _mapper = mapper;
        }

        [SwaggerOperation(
         Summary = "List all meetings",
         Description = "List of meetings",
         OperationId = "ListAllmeetings")]
        [SwaggerResponse(200, "List of meetings", typeof(IEnumerable<MeetingResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MeetingResource>), 200)]
        public async Task<IEnumerable<MeetingResource>> GetAllAsync()
        {
            var meetings = await _meetingService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Meeting>, IEnumerable<MeetingResource>>(meetings);
            return resources;
        }



        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MeetingResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _meetingService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var meetingResource = _mapper.Map<Meeting, MeetingResource>(result.Resource);//de Entity a Resource
            return Ok(meetingResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(MeetingResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveMeetingResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var meeting = _mapper.Map<SaveMeetingResource, Meeting>(resource);
            var result = await _meetingService.SaveAsync(meeting);

            if (!result.Success)
                return BadRequest(result.Message);
            var meetingResource = _mapper.Map<Meeting, MeetingResource>(result.Resource);
            return Ok(meetingResource);
        }

        [SwaggerOperation(
            Summary = "Delete Meeting",
            Description = "Delete Meeting by Id",
            OperationId = "DeleteMeeting")]
        [HttpDelete("{accountId}")]
        [ProducesResponseType(typeof(MeetingResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int meetingId)
        {
            var result = await _meetingService.DeleteAsync(meetingId);
            if (!result.Success)
                return BadRequest(result.Message);
            var meetingResource = _mapper.Map<Meeting, MeetingResource>(result.Resource);
            return Ok(meetingResource);
        }
    }
}