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
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MeetingService(IMeetingRepository meetingRepository, IUnitOfWork unitOfWork)
        {
            _meetingRepository = meetingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MeetingResponse> DeleteAsync(int id)
        {
            var existingMeeting = await _meetingRepository.FindById(id);

            if (existingMeeting == null)
                return new MeetingResponse("Tag not found");

            try
            {
                _meetingRepository.Remove(existingMeeting);
                await _unitOfWork.CompleteAsync();

                return new MeetingResponse(existingMeeting);

            }
            catch (Exception ex)
            {
                return new MeetingResponse($"An error ocurred while deleting meeting: {ex.Message}");
            }
        }

        public async Task<MeetingResponse> GetByIdAsync(int meetingId)
        {
            var existingMeeting = await _meetingRepository.FindById(meetingId);

            if (existingMeeting == null)
                return new MeetingResponse("Meeting not found");

            return new MeetingResponse(existingMeeting);
        }

        public async Task<IEnumerable<Meeting>> ListAsync()
        {
            return await _meetingRepository.ListAsync();
        }

        public async Task<MeetingResponse> SaveAsync(Meeting meeting)
        {
            try
            {
                await _meetingRepository.AddAsync(meeting);
                await _unitOfWork.CompleteAsync();

                return new MeetingResponse(meeting);
            }
            catch (Exception ex)
            {
                return new MeetingResponse($"An error ocurred while saving meeting: {ex.Message}");
            }
        }

        public async Task<MeetingResponse> UpdateAsync(int id, Meeting meeting)
        {
            var existingMeeting = await _meetingRepository.FindById(id);

            if (existingMeeting == null)
                return new MeetingResponse("Meeting not found");

            existingMeeting.Id = meeting.Id;

            try
            {
                _meetingRepository.Update(meeting);
                await _unitOfWork.CompleteAsync();

                return new MeetingResponse(meeting);
            }
            catch (Exception ex)
            {
                return new MeetingResponse($"An error ocurred while updating meeting: {ex.Message}");
            }
        }
    }
}
