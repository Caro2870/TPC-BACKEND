using System;
 using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class MeetingRepository : BaseRepository, IMeetingRepository
 	{
 
 		public MeetingRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(Meeting meeting)
 		{
 			await _context.Meetings.AddAsync(meeting);
 		}
 
 		public async Task<Meeting> FindById(int id)
 		{
 			return await _context.Meetings.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<Meeting>> ListAsync()
 		{
 			return await _context.Meetings.ToListAsync();
 		}

        public void Remove(Meeting meeting)
 		{
 			_context.Meetings.Remove(meeting);
 		}
 
 		public void Update(Meeting meeting)
 		{
 			_context.Meetings.Update(meeting);
 		}

        public async Task<IEnumerable<Meeting>> ListByRangeOfDates(DateTime start, DateTime end)
        {
            return await _context.Meetings
                .Where(ls => ls.StartDate >= start && ls.StartDate <= end)
                .ToListAsync();
        }
    }
 }