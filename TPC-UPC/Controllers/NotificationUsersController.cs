using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services;
using TPC_UPC.Resources;

namespace TPC_UPC.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/notifications")]
    public class NotificationUsersController : ControllerBase
    {
        private readonly INotificationUserService _notificationUserService;
        private readonly IMapper _mapper;

        public NotificationUsersController(INotificationUserService notificationUserService, IMapper mapper)
        {
            _notificationUserService = notificationUserService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotificationUserResource>> GetAllNotificationsByUserIdAsync(int userId)
        {
            var notifications = await _notificationUserService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<NotificationUser>, IEnumerable<NotificationUserResource>>(notifications);
            return resources;
        }
    }
}
