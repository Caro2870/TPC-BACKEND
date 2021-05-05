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
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            _notificationRepository = notificationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<NotificationResponse> DeleteAsync(int id)
        {
            var existingCategory = await _notificationRepository.FindById(id);

            if (existingCategory == null)
                return new NotificationResponse("Notification not found");

            try
            {
                _notificationRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new NotificationResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new NotificationResponse($"An error ocurred while deleting the notification: {ex.Message}");
            }
        }

        public async Task<NotificationResponse> GetByIdAsync(int id)
        {
            var existingNotification = await _notificationRepository.FindById(id);

            if (existingNotification == null)
                return new NotificationResponse("Notification not found");
            return new NotificationResponse(existingNotification);
        }

        public async Task<IEnumerable<Notification>> ListAsync()
        {
            return await _notificationRepository.ListAsync();
        }

        public async Task<NotificationResponse> SaveAsync(Notification notification)
        {
            try
            {
                await _notificationRepository.AddAsync(notification);
                await _unitOfWork.CompleteAsync();

                return new NotificationResponse(notification);
            }
            catch (Exception ex)
            {
                return new NotificationResponse($"An error ocurred while saving the notification: {ex.Message}");
            }
        }

        public async Task<NotificationResponse> UpdateAsync(int id, Notification notification)
        {
            var existingNotification = await _notificationRepository.FindById(id);

            if (existingNotification == null)
                return new NotificationResponse("Notification not found");

            existingNotification.Link = notification.Link;

            try
            {
                _notificationRepository.Update(existingNotification);
                await _unitOfWork.CompleteAsync();

                return new NotificationResponse(existingNotification);
            }
            catch (Exception ex)
            {
                return new NotificationResponse($"An error ocurred while updating the notification: {ex.Message}");
            }
        }
    }
}
