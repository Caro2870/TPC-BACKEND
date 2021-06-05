using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
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
        //new
        Task<IEnumerable<Meeting>> ListByRangeOfDates(DateTime start, DateTime end);
    }
}
