using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Resources;

namespace TPC_UPC.Services
{
    public class MailMessageService : IMailMessageService
    {
        public readonly IMailMessageRepository _mailMessageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoordinatorRepository _coordinatorRepository;

        public MailMessageService(IMailMessageRepository mailMessageRepository, ICoordinatorRepository coordinatorRepository, IUnitOfWork unitOfWork)
        {
            _coordinatorRepository = coordinatorRepository;
            _mailMessageRepository = mailMessageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MailMessageResponse> DeleteAsync(int id)
        {
            var existingMailMessage = await _mailMessageRepository.FindById(id);

            if (existingMailMessage == null)
                return new MailMessageResponse("Mail message not found");

            try
            {
                _mailMessageRepository.Remove(existingMailMessage);
                await _unitOfWork.CompleteAsync();

                return new MailMessageResponse(existingMailMessage);

            }
            catch (Exception ex)
            {
                return new MailMessageResponse($"An error ocurred while deleting faculty: {ex.Message}");
            }
        }

        public async Task<MailMessageResponse> GetByIdAsync(int id)
        {
            var existingmailMessage = await _mailMessageRepository.FindById(id);

            if (existingmailMessage == null)
                return new MailMessageResponse("mailMessage not found");

            return new MailMessageResponse(existingmailMessage);
        }

        public async Task<IEnumerable<MailMessage>> ListAsync()
        {
            return await _mailMessageRepository.ListAsync();
        }

        public async Task<IEnumerable<MailMessage>> ListByCoordinatorIdAsync(int coordinatorId)
        {
            return await _mailMessageRepository.ListByCoordinatorIdAsync(coordinatorId);
        }

        public async Task<MailMessageResponse> SaveAsync(MailMessage mailMessage, int coordinatorId)
        {
            if (_coordinatorRepository.FindById(coordinatorId) != null)
            {
                try
                {
                    mailMessage.CoordinatorId = coordinatorId;
                    await _mailMessageRepository.AddAsync(mailMessage);
                    await _unitOfWork.CompleteAsync();
                    return new MailMessageResponse(mailMessage);
                }
                catch (Exception e)
                {
                    return new MailMessageResponse($"An error ocurred while saving {e.Message}");
                }
            }
            else
            {
                return new MailMessageResponse($"An error ocurred, the coordinator with id {coordinatorId} doesn't exist");
            }
        }

        public async Task<MailMessageResponse> UpdateASync(int id, MailMessage mailMessage)
        {
            var existingMailMessage = await _mailMessageRepository.FindById(id);

            if (existingMailMessage == null)
                return new MailMessageResponse("Faculty not found");

            existingMailMessage.Message = mailMessage.Message;

            try
            {
                _mailMessageRepository.Update(mailMessage);
                await _unitOfWork.CompleteAsync();

                return new MailMessageResponse(mailMessage);
            }
            catch (Exception ex)
            {
                return new MailMessageResponse($"An error ocurred while updating the mail message: {ex.Message}");
            }
        }
    }
}
