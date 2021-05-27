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
 	public class UserCourseRepository : BaseRepository, IUserCourseRepository
 	{
 
 		public UserCourseRepository(AppDbContext context) : base(context)
 		{
 		}
 
 		public async Task AddAsync(UserCourse userCourse)
 		{
 			await _context.UserCourses.AddAsync(userCourse);
 		}

        public async Task AssignUserCourse(int userId, int courseId)
        {
            UserCourse userCourse = await FindByUserIdAndCourseId(userId, courseId);
            if (userCourse == null)
            {
                userCourse = new UserCourse { UserId = userId, CourseId = courseId };
                await AddAsync(userCourse);
            }
        }

        public async Task<UserCourse> FindByUserIdAndCourseId(int userId, int courseId)
        {
            return await _context.UserCourses.FindAsync(userId, courseId);
        }

        public async Task<IEnumerable<UserCourse>> ListAsync()
 		{
            return await _context.UserCourses
                .Include(pt => pt.User)
                .Include(pt => pt.Course)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserCourse>> ListByCourseIdAsync(int courseId)
        {
            return await _context.UserCourses
                .Where(pt => pt.CourseId == courseId)
                .Include(pt => pt.User)
                .Include(pt => pt.Course)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserCourse>> ListByUserIdAsync(int userId)
        {
            return await _context.UserCourses
                .Where(pt => pt.UserId == userId)
                .Include(pt => pt.User)
                .Include(pt => pt.Course)
                .ToListAsync();
        }

        public void Remove(UserCourse userCourse)
 		{
 			_context.UserCourses.Remove(userCourse);
 		}

        public async void UnassignUserCourse(int userId, int courseId)
        {
            UserCourse userCourse = await _context.UserCourses.FindAsync(userId, courseId);
            if (userCourse != null)
                Remove(userCourse);
        }

        public void Update(UserCourse userCourse)
 		{
 			_context.UserCourses.Update(userCourse);
 		}
 	}
 }