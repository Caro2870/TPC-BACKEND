using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class LessonTypeRepository : BaseRepository, ILessonTypeRepository
 	{
 
 		public LessonTypeRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(LessonType lessonType)
 		{
 			await _context.LessonTypes.AddAsync(lessonType);
 		}
 
 		public async Task<LessonType> FindById(int id)
 		{
 			return await _context.LessonTypes.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<LessonType>> ListAsync()
 		{
 			return await _context.LessonTypes.ToListAsync();
 		}
 
 		public void Remove(LessonType lessonType)
 		{
 			_context.LessonTypes.Remove(lessonType);
 		}
 
 		public void Update(LessonType lessonType)
 		{
 			_context.LessonTypes.Update(lessonType);
 		}
 	}
 }