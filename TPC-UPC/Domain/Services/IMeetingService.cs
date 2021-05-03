using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;
using Web.Domain.Services.Communications;

namespace Web.Domain.Services
{
    public interface IMeetingService
    {
        //CRUD
        Task<MeetingResponse> GetByIdAsync(int meetingId);
        Task<MeetingResponse> UpdateAsync(int id, Meeting meeting);
        Task<MeetingResponse> DeleteAsync(int id);
        Task<MeetingResponse> SaveAsync(Meeting meeting);

        //ADDED
        Task<IEnumerable<Meeting>> ListAsync();
        Task<IEnumerable<Meeting>> ListByScheduleIdAsync(int scheduleId);
    }
}
