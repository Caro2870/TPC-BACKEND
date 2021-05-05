using System;
 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using TPC_UPC.Domain.Models;
 using TPC_UPC.Domain.Persistence.Contexts;
 using TPC_UPC.Domain.Persistence.Repositories;
 
 namespace TPC_UPC.Persistence.Repositories
 {
 	public class UserCourseRepository : BaseRepository, IUserCourseRepository
 	{
 
 		public UserCourseRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(UserCourse userCourse)
 		{
 			await _context.UserCourses.AddAsync(userCourse);
 		}
 
 		public async Task<UserCourse> FindById(int id)
 		{
 			return await _context.UserCourses.FindAsync(id);
 		}
 
 		public async Task<IEnumerable<UserCourse>> ListAsync()
 		{
 			return await _context.UserCourses.ToListAsync();
 		}
 
 		public void Remove(UserCourse userCourse)
 		{
 			_context.UserCourses.Remove(userCourse);
 		}
 
 		public void Update(UserCourse userCourse)
 		{
 			_context.UserCourses.Update(userCourse);
 		}
 	}
 }