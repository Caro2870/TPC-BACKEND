using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Services
{
    public class NotificationUserService : INotificationUserService
    {
        private readonly INotificationUserRepository _notificationUserRepository;
        private IUnitOfWork _unitOfWork;

        public Task<NotificationUserResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationUserResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NotificationUser>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NotificationUser>> ListByUserIdAsync(int userId)
        {
            return await _notificationUserRepository.ListByUserId(userId); 
        }

        public Task<NotificationUserResponse> SaveAsync(NotificationUser notificationUser)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationUserResponse> UpdateAsync(int id, NotificationUser notificationUser)
        {
            throw new NotImplementedException();
        }
    }
}
