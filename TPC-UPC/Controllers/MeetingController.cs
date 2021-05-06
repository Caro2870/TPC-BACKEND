using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.API.Extensions;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services;
using TPC_UPC.Resources;
using TPC_UPC.Services;

namespace TPC_UPC.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;
        private readonly IMapper _mapper;

        public MeetingController(IMeetingService meetingService, IMapper mapper)
        {
            _meetingService = meetingService;
            _mapper = mapper;
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
    }
}