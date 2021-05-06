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

namespace TPC_UPC.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<NotificationResource>), 200)]
        public async Task<IEnumerable<NotificationResource>> GetAllAsync()
        {
            var notifications = await _notificationService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Notification>, IEnumerable<NotificationResource>>(notifications);
            return resources;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NotificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _notificationService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var notificationResource = _mapper.Map<Notification, NotificationResource>(result.Resource);
            return Ok(notificationResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(NotificationResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync([FromBody] SaveNotificationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var notification = _mapper.Map<SaveNotificationResource, Notification>(resource);
            var result = await _notificationService.SaveAsync(notification);

            if (!result.Success)
                return BadRequest(result.Message);

            var notificationResource = _mapper.Map<Notification, NotificationResource>(result.Resource);
            return Ok(notificationResource);
        }
    }
}