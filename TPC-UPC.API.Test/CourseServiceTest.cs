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
    class CourseServiceTest
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
            var mockUserCourseRepository = GetDefaultIUserCourseRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Course course = new Course();
            mockCourseRepository.Setup(r => r.AddAsync(course))
                .Returns(Task.FromResult<Course>(course));
            var service = new CourseService(mockCourseRepository.Object,
                mockIUnitOfWork.Object, mockUserCourseRepository.Object);
            //
            CourseResponse result = await service.SaveAsync(course);
            var message = result.Message;
            //
            message.Should().Be("");
        }

        [Test]
        public async Task GetAsyncTestHappy()
        {
            // Arrange
            var mockCourseRepository = GetDefaultICourseRepositoryInstance();
            var mockUserCourseRepository = GetDefaultIUserCourseRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Course course = new Course();
            int courseId = 1;
            course.Id = courseId;
            mockCourseRepository.Setup(r => r.FindById(courseId))
                .Returns(Task.FromResult<Course>(course));

            var service = new CourseService(mockCourseRepository.Object,
                mockIUnitOfWork.Object, mockUserCourseRepository.Object);

            // Act
            CourseResponse result = await service.GetByIdAsync(courseId);

            // Assert
            Assert.AreEqual(course, result.Resource);
        }

        [Test]
        public async Task DeleteAsyncTestHappy()
        {
            // Arrange
            var mockCourseRepository = GetDefaultICourseRepositoryInstance();
            var mockUserCourseRepository = GetDefaultIUserCourseRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Course course = new Course();
            int courseId = 1;
            course.Id = courseId;

            mockCourseRepository.Setup(r => r.FindById(courseId))
                .Returns(Task.FromResult<Course>(course));

            var service = new CourseService(mockCourseRepository.Object,
                mockIUnitOfWork.Object, mockUserCourseRepository.Object);

            // Act
            CourseResponse result = await service.DeleteAsync(courseId);

            // Assert
            Assert.AreEqual(course, result.Resource);
        }
        [Test]
        public async Task PutAsyncTest()
        {
            // Arrange
            var mockCourseRepository = GetDefaultICourseRepositoryInstance();
            var mockUserCourseRepository = GetDefaultIUserCourseRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Course course = new Course();
            int courseId = 1;
            course.Id = courseId;
            course.Name = "CPL";

            Course courseExpected = new Course();
            courseExpected.Name = "Mate";

            mockCourseRepository.Setup(r => r.FindById(courseId))
                .Returns(Task.FromResult<Course>(course));

            var service = new CourseService(mockCourseRepository.Object,
                mockIUnitOfWork.Object, mockUserCourseRepository.Object);

            // Act
            CourseResponse result = await service.UpdateAsync(courseId, courseExpected);

            // Assert
            Assert.AreEqual(courseExpected.Name, result.Resource.Name);
        }

        [Test]
        public async Task GetAsyncTestUnhappy()
        {
            // Arrange
            var mockCourseRepository = GetDefaultICourseRepositoryInstance();
            var mockUserCourseRepository = GetDefaultIUserCourseRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            int courseId = 1;

            var service = new CourseService(mockCourseRepository.Object,
                mockIUnitOfWork.Object, mockUserCourseRepository.Object);

            // Act
            CourseResponse result = await service.GetByIdAsync(courseId);
            var message = result.Message;

            // Assert
            message.Should().Be("Course not found");
        }

        private Mock<ICourseRepository> GetDefaultICourseRepositoryInstance()
        {
            return new Mock<ICourseRepository>();
        }

        private Mock<IUserCourseRepository> GetDefaultIUserCourseRepositoryInstance()
        {
            return new Mock<IUserCourseRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
