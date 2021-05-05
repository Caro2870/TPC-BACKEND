using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface IScheduleService
    {
        //CRUD
        Task<ScheduleResponse> SaveAsync(Schedule schedule);
        Task<ScheduleResponse> GetByIdAsync(int scheduleId);
        Task<ScheduleResponse> UpdateAsync(int id, Schedule schedule);
        Task<ScheduleResponse> DeleteAsync(int id);

        //ADDED
        Task<IEnumerable<Schedule>> ListAsync();
        Task<IEnumerable<Schedule>> ListByMeetingIdAsync(int meetingId);
    }
}
