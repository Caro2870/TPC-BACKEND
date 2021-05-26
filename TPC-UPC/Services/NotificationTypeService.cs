using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Services
{
    public class NotificationTypeService : INotificationTypeService
    {
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationTypeService(INotificationTypeRepository notificationTypeRepository, IUnitOfWork unitOfWork)
        {
            _notificationTypeRepository = notificationTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<NotificationTypeResponse> DeleteAsync(int id)
        {
            var existingNotificationType = await _notificationTypeRepository.FindById(id);
            try
            {
                _notificationTypeRepository.Remove(existingNotificationType);
                await _unitOfWork.CompleteAsync();

                return new NotificationTypeResponse(existingNotificationType);
            }
            catch (Exception ex)
            {
                return new NotificationTypeResponse($"An error ocurred while deleting the notification type: {ex.Message}");
            }
        }

        public async Task<NotificationTypeResponse> GetByIdAsync(int id)
        {
            var existingNotificationType = await _notificationTypeRepository.FindById(id);

            if (existingNotificationType == null)
                return new NotificationTypeResponse("Notification type not found");
            return new NotificationTypeResponse(existingNotificationType);
        }

        public async Task<IEnumerable<NotificationType>> ListAsync()
        {
            return await _notificationTypeRepository.ListAsync();
        }

        public async Task<NotificationTypeResponse> SaveAsync(NotificationType nt)
        {
            try
            {
                await _notificationTypeRepository.AddAsync(nt);
                await _unitOfWork.CompleteAsync();

                return new NotificationTypeResponse(nt);
            }
            catch (Exception ex)
            {
                return new NotificationTypeResponse($"An error ocurred while saving the notification type: {ex.Message}");
            }
        }

        public async Task<NotificationTypeResponse> UpdateAsync(int id, NotificationType nt)
        {
            var existingNotificationType = await _notificationTypeRepository.FindById(id);

            if (existingNotificationType == null)
                return new NotificationTypeResponse("Notification type not found");

            existingNotificationType.Description = nt.Description;

            try
            {
                _notificationTypeRepository.Update(existingNotificationType);
                await _unitOfWork.CompleteAsync();
                return new NotificationTypeResponse(existingNotificationType);
            }
            catch (Exception ex)
            {
                return new NotificationTypeResponse($"An error ocurred while updating the notification type: {ex.Message}");
            }
        }
    }
}
