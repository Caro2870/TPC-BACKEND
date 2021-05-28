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
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationUsersController : ControllerBase
    {
        private readonly INotificationUserService _notificationUserService;
        private readonly IMapper _mapper;

        public NotificationUsersController(INotificationUserService notificationUserService, IMapper mapper)
        {
            _notificationUserService = notificationUserService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveNotificationUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var nu = _mapper.Map<SaveNotificationUserResource, NotificationUser>(resource);
            var result = await _notificationUserService.SaveAsync(nu);

            if (!result.Success)
                return BadRequest(result.Message);
            var nuResource = _mapper.Map<NotificationUser, NotificationUserResource>(result.Resource);
            return Ok(nuResource);
        }

        /*[HttpGet("/notifications/{notificationId}/users/{userId}")]
        public async Task<IActionResult> GetAsync(int notificationId, int userId)
        {
            var result = await _notificationUserService.GetById(notificationId, userId);
            if (!result.Success)
                return BadRequest(result.Message);
            var nuResource = _mapper.Map<NotificationUser, NotificationUserResource>(result.Resource);
            return Ok(nuResource);
        }*/

        [HttpDelete("/notifications/{notificationId}/users/{userId}")]
        public async Task<IActionResult> DeleteAsync(int notificationId, int userId)
        {
            var result = await _notificationUserService.DeleteAsync(notificationId, userId);
            if (!result.Success)
                return BadRequest(result.Message);
            var nuResource = _mapper.Map<NotificationUser, NotificationUserResource>(result.Resource);
            return Ok(nuResource);
        }

        [HttpPut("/notifications/{notificationId}/users/{userId}")]
        public async Task<IActionResult> PostAsync(int notificationId, int userId, [FromBody] SaveNotificationUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var nu = _mapper.Map<SaveNotificationUserResource, NotificationUser>(resource);
            var result = await _notificationUserService.UpdateAsync(notificationId,userId,nu);

            if (!result.Success)
                return BadRequest(result.Message);
            var nuResource = _mapper.Map<NotificationUser, NotificationUserResource>(result.Resource);
            return Ok(nuResource);
        }

        //Lists
        [HttpGet]
        public async Task<IEnumerable<NotificationUserResource>> GetAllAsync()
        {
            var notificationsusers = await _notificationUserService.ListAsync();
            var resources = _mapper.Map<IEnumerable<NotificationUser>, IEnumerable<NotificationUserResource>>(notificationsusers);
            return resources;
        }

        [HttpGet("/users/{userId}")]
        public async Task<IEnumerable<NotificationUserResource>> GetAllByUserIdAsync(int userId)
        {
            var notificationsusers = await _notificationUserService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<NotificationUser>, IEnumerable<NotificationUserResource>>(notificationsusers);
            return resources;
        }

        [HttpGet("/notifications/{notificationId}")]
        public async Task<IEnumerable<NotificationUserResource>> GetAllByNotificationIdAsync(int notificationId)
        {
            var notificationsusers = await _notificationUserService.ListByNotificationIdAsync(notificationId);
            var resources = _mapper.Map<IEnumerable<NotificationUser>, IEnumerable<NotificationUserResource>>(notificationsusers);
            return resources;
        }

    }
}
