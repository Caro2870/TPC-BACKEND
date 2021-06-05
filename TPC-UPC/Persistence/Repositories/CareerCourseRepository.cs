using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Contexts;
using TPC_UPC.Domain.Persistence.Repositories;

namespace TPC_UPC.Persistence.Repositories
{
    public class CareerCourseRepository : BaseRepository, ICareerCourseRepository
    {

        public CareerCourseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(CareerCourse careerCourse)
        {
            await _context.CareerCourses.AddAsync(careerCourse);
        }

        public async Task AssignCareerCourse(int careerId, int courseId)
        {
            CareerCourse careerCourse = await FindByCareerIdAndCourseId(careerId, courseId);
            if (careerCourse == null)
            {
                careerCourse = new CareerCourse { CareerId = careerId, CourseId = courseId };
                await AddAsync(careerCourse);
            }
        }

        public async Task<CareerCourse> FindByCareerIdAndCourseId(int careerId, int courseId)
        {
            return await _context.CareerCourses.FindAsync(careerId, courseId);
        }

        public async Task<IEnumerable<CareerCourse>> ListAsync()
        {
            return await _context.CareerCourses
                .Include(pt => pt.Career)
                .Include(pt => pt.Course)
                .ToListAsync();
        }

        public async Task<IEnumerable<CareerCourse>> ListByCourseIdAsync(int courseId)
        {
            return await _context.CareerCourses
                .Where(pt => pt.CourseId == courseId)
                .Include(pt => pt.Career)
                .Include(pt => pt.Course)
                .ToListAsync();
        }

        public async Task<IEnumerable<CareerCourse>> ListByCareerIdAsync(int careerId)
        {
            return await _context.CareerCourses
                .Where(pt => pt.CareerId == careerId)
                .Include(pt => pt.Career)
                .Include(pt => pt.Course)
                .ToListAsync();
        }

        public void Remove(CareerCourse careerCourse)
        {
            _context.CareerCourses.Remove(careerCourse);
        }

        public async void UnassignCareerCourse(int careerId, int courseId)
        {
            CareerCourse careerCourse = await _context.CareerCourses.FindAsync(careerId, courseId);
            if (careerCourse != null)
                Remove(careerCourse);
        }

        public void Update(CareerCourse careerCourse)
        {
            _context.CareerCourses.Update(careerCourse);
        }
    }
}
