using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class ScheduleRepository : BaseRepository, IScheduleRepository
 	{
 
 		public ScheduleRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(Schedule schedule)
 		{
 			await _context.Schedules.AddAsync(schedule);
 		}
 
 		public async Task<Schedule> FindById(int id)
 		{
 			return await _context.Schedules.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<Schedule>> ListAsync()
 		{
 			return await _context.Schedules.ToListAsync();
 		}
 
 		public void Remove(Schedule schedule)
 		{
 			_context.Schedules.Remove(schedule);
 		}
 
 		public void Update(Schedule schedule)
 		{
 			_context.Schedules.Update(schedule);
 		}
 	}
 }