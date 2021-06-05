using NUnit.Framework;
using Moq;
using FluentAssertions;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using TPC_UPC.Services;

namespace TPC_UPC.API.Test
{
    /*class CourseServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenCoursesReturnsSuccess()
        {
            //
            var mockCourseRepository = GetDefaultICourseRepositoryInstance();
            var mockLessonRepository = GetDefaultILessonRepositoryInstance();
            var mockLessonStudentRepository = GetDefaultILessonStudentRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Course course = new Course();
            mockCourseRepository.Setup(r => r.AddAsync(course))
                .Returns(Task.FromResult<Course>(course));
            var service = new CourseService(mockCourseRepository.Object, mockLessonRepository.Object, mockLessonStudentRepository.Object, mockIUnitOfWork.Object);
            //
            CourseResponse result = await service.SaveAsync(course);
            var message = result.Message;
            //
            message.Should().Be("");
        }

        [Test]
        public async Task GetAllAsyncWhenCoursesReturnsSuccess()
        {
            //
            var mockCourseRepository = GetDefaultICourseRepositoryInstance();
            var mockLessonRepository = GetDefaultILessonRepositoryInstance();
            var mockLessonStudentRepository = GetDefaultILessonStudentRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            mockCourseRepository.Setup(r => r.ListAsync());
            var service = new CourseService(mockCourseRepository.Object, mockLessonRepository.Object, mockLessonStudentRepository.Object, mockIUnitOfWork.Object);
            //
            //    CourseResponse result = await service.ListAsync();
            //    var message = result.Message;
            //    //
            //    message.Should().Be("");
        }

        private Mock<ICourseRepository> GetDefaultICourseRepositoryInstance()
        {
            return new Mock<ICourseRepository>();
        }

        private Mock<ILessonRepository> GetDefaultILessonRepositoryInstance()
        {
            return new Mock<ILessonRepository>();
        }

        private Mock<ILessonStudentRepository> GetDefaultILessonStudentRepositoryInstance()
        {
            return new Mock<ILessonStudentRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }*/
}
