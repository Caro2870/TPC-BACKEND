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
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMeetingRepository _meetingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public async Task<ScheduleResponse> DeleteAsync(int id)
        {
            var existingSchedule = await _scheduleRepository.FindById(id);

            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");

            try
            {
                _scheduleRepository.Remove(existingSchedule);
                await _unitOfWork.CompleteAsync();

                return new ScheduleResponse(existingSchedule);

            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while deleting schedule: {ex.Message}");
            }
        }

        public async Task<ScheduleResponse> GetByIdAsync(int scheduleId)
        {
            var existingSchedule = await _scheduleRepository.FindById(scheduleId);

            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");

            return new ScheduleResponse(existingSchedule);
        }

        public async Task<IEnumerable<Schedule>> ListAsync()
        {
            return await _scheduleRepository.ListAsync();
        }

        public async Task<IEnumerable<Schedule>> ListByMeetingIdAsync(int meetingId)
        {
            //return await _scheduleRepository.ListByMeetingIdAsync(meetingId);
        }

        public async Task<ScheduleResponse> SaveAsync(Schedule schedule)
        {
            try
            {
                await _scheduleRepository.AddAsync(schedule);
                await _unitOfWork.CompleteAsync();

                return new ScheduleResponse(schedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while saving schedule: {ex.Message}");
            }
        }

        public async Task<ScheduleResponse> UpdateAsync(int id, Schedule schedule)
        {
            var existingSchedule = await _scheduleRepository.FindById(id);

            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");

            existingSchedule.Id = schedule.Id;

            try
            {
                _scheduleRepository.Update(schedule);
                await _unitOfWork.CompleteAsync();

                return new ScheduleResponse(schedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while updating schedule: {ex.Message}");
            }
        }
    }
}
