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
        private readonly IUnitOfWork _unitOfWork;

        public NotificationUserService(INotificationUserRepository notificationUserRepository, IUnitOfWork unitOfWork)
        {
            _notificationUserRepository = notificationUserRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<NotificationUserResponse> UpdateAsync(int notificationId, int userId, NotificationUser notificationUser)
        {
            var existingNotificationUser = await _notificationUserRepository.FindById(notificationId,userId);

            if (existingNotificationUser == null)
                return new NotificationUserResponse("Notification user not found");

            existingNotificationUser.NotificationId = notificationUser.NotificationId;
            existingNotificationUser.UserId = notificationUser.UserId;

            try
            {
                _notificationUserRepository.Update(existingNotificationUser);
                await _unitOfWork.CompleteAsync();
                return new NotificationUserResponse(existingNotificationUser);

            }
            catch (Exception ex)
            {
                return new NotificationUserResponse($"An error ocurred while updating the notification user: {ex.Message}");
            }
        }

        public async Task<NotificationUserResponse> DeleteAsync(int notificationId, int userId)
        {
            var existingNotificationUser = await _notificationUserRepository.FindById(notificationId, userId);

            if (existingNotificationUser == null)
                return new NotificationUserResponse("Notification user not found");

            try
            {
                _notificationUserRepository.Remove(existingNotificationUser);
                await _unitOfWork.CompleteAsync();

                return new NotificationUserResponse(existingNotificationUser);
            }
            catch (Exception ex)
            {
                return new NotificationUserResponse($"An error ocurred while deleting the notification user: {ex.Message}");
            }
        }

        public async Task<NotificationUserResponse> GetById(int notificationId, int userId)
        {
            var existingNotificationUser = await _notificationUserRepository.FindById(notificationId, userId);

            if (existingNotificationUser == null)
                return new NotificationUserResponse("Notification user not found");
            return new NotificationUserResponse(existingNotificationUser);
        }

        public async Task<NotificationUserResponse> SaveAsync(NotificationUser notificationUser)
        {
            try
            {
                await _notificationUserRepository.AddAsync(notificationUser);
                await _unitOfWork.CompleteAsync();

                return new NotificationUserResponse(notificationUser);
            }
            catch (Exception ex)
            {
                return new NotificationUserResponse($"An error ocurred while saving the notification user: {ex.Message}");
            }
        }


        //Lists
        public async Task<IEnumerable<NotificationUser>> ListAsync()
        {
            return await _notificationUserRepository.ListAsync();
        }

        public async Task<IEnumerable<NotificationUser>> ListByNotificationIdAsync(int notificationId)
        {
            return await _notificationUserRepository.ListByNotificationId(notificationId);
        }

        public async Task<IEnumerable<NotificationUser>> ListByUserIdAsync(int userId)
        {
            return await _notificationUserRepository.ListByUserId(userId);
        }
    }
}
