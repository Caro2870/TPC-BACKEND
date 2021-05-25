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
    [Produces("application/json")]
    [Route("/api/coordinators/{coordinatorId}/mailMessages")]
    public class CoordinatorMailMessagesController : ControllerBase
    {
        private readonly IMailMessageService _mailMessageService;
        private readonly IMapper _mapper;

        public CoordinatorMailMessagesController(IMailMessageService mailMessageService, IMapper mapper)
        {
            _mailMessageService = mailMessageService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all mail messages of a coordinator",
            Description = "List all mail messages of a coordinator",
            OperationId = "List all mail messages of a coordinator")]
        [SwaggerResponse(200, "List all mail messages of a coordinator", typeof(IEnumerable<MailMessageResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MailMessageResource>), 200)]
        public async Task<IEnumerable<MailMessageResource>> GetAllAsync(int coordinatorId)
        {

            var faculties = await _mailMessageService.ListByCoordinatorIdAsync(coordinatorId);
            var resources = _mapper
                .Map<IEnumerable<MailMessage>, IEnumerable<MailMessageResource>>(faculties);
            return resources;
        }

        [HttpPost]
        [ProducesResponseType(typeof(MailMessageResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveMailMessageResource resource, int coordinatorId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var mailMessage = _mapper.Map<SaveMailMessageResource, MailMessage>(resource);
            var result = await _mailMessageService.SaveAsync(mailMessage, coordinatorId);

            if (!result.Success)
                return BadRequest(result.Message);

            var mailMessageResource = _mapper.Map<MailMessage, MailMessageResource>(result.Resource);
            return Ok(mailMessageResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MailMessageResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMailMessageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var mailMessage = _mapper.Map<SaveMailMessageResource, MailMessage>(resource);
            var result = await _mailMessageService.UpdateASync(id, mailMessage);

            if (!result.Success)
                return BadRequest(result.Message);

            var MailMessageResource = _mapper.Map<MailMessage, MailMessageResource>(result.Resource);
            return Ok(MailMessageResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MailMessageResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _mailMessageService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var mailMessageResource = _mapper.Map<MailMessage, MailMessageResource>(result.Resource);
            return Ok(mailMessageResource);
        }
    }
}
