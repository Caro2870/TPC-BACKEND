using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.API.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services;
using TPC_UPC.Resources;
using Swashbuckle.Swagger;

namespace TPC_UPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationTypeController : ControllerBase
    {
        private readonly INotificationTypeService _notificationTypeService;
        private readonly IMapper _mapper;

        public NotificationTypeController(INotificationTypeService notificationTypeService, IMapper mapper)
        {
            _notificationTypeService = notificationTypeService;
            _mapper = mapper;
        }

        /*[SwaggerOperation(
            Summary = "Add Account",
            Description = "Add Account by Id",
            OperationId = "AddAccount")]*/
        [HttpPost]
        [ProducesResponseType(typeof(NotificationTypeResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveNotificationTypeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var notificationType = _mapper.Map<SaveNotificationTypeResource,NotificationType>(resource);
            var result = await _notificationTypeService.SaveAsync(notificationType);

            if (!result.Success)
                return BadRequest(result.Message);
            var notificationTypeResource = _mapper.Map<NotificationType, NotificationTypeResource>(result.Resource);
            return Ok(notificationTypeResource);
        }

        [HttpPut("{notificationTypeId}")]
        [ProducesResponseType(typeof(AccountResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PutAsync(int notificationTypeId, [FromBody] SaveNotificationTypeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var notificationType = _mapper.Map<SaveNotificationTypeResource, NotificationType>(resource);
            var result = await _notificationTypeService.UpdateAsync(notificationTypeId, notificationType);

            if (!result.Success)
                return BadRequest(result.Message);
            var notificationTypeResource = _mapper.Map<NotificationType, NotificationTypeResource>(result.Resource);
            return Ok(notificationTypeResource);
        }

        [HttpGet("{notificationTypeId}")]
        [ProducesResponseType(typeof(AccountResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int notificationTypeId)
        {
            var result = await _notificationTypeService.GetByIdAsync(notificationTypeId);

            if (!result.Success)
                return BadRequest(result.Message);

            var notificationTypeResource = _mapper.Map<NotificationType, NotificationTypeResource>(result.Resource);

            return Ok(notificationTypeResource);
        }


        [HttpDelete("{notificationTypeId}")]
        [ProducesResponseType(typeof(AccountResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int notificationTypeId)
        {
            var result = await _notificationTypeService.DeleteAsync(notificationTypeId);
            if (!result.Success)
                return BadRequest(result.Message);
            var notificationTypeResource = _mapper.Map<NotificationType, NotificationTypeResource>(result.Resource);
            return Ok(notificationTypeResource);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NotificationTypeResource>), 200)]
        public async Task<IEnumerable<NotificationTypeResource>> GetAllAsync()
        {
            var notificationTypes = await _notificationTypeService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<NotificationType>, IEnumerable<NotificationTypeResource>>(notificationTypes);
            return resources;
        }
    }
}
