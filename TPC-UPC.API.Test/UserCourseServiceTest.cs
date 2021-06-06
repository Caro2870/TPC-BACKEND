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
    class UserCourseServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenUserCoursesReturnSuccess()
        {
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockUserCourseRepository = GetDefaultIUserCourseRepositoryInstance();

            UserCourse userCourse = new UserCourse();
            int courseId =1, userId = 1;
            userCourse.CourseId = courseId;
            userCourse.UserId = userId;
            mockUserCourseRepository.Setup(r => r.AssignUserCourse(userId, courseId))
                .Returns(Task.FromResult<UserCourse>(userCourse));

            var service = new UserCourseService(mockUserCourseRepository.Object, 
                mockUnitOfWork.Object);
            UserCourseResponse result = await service.AssignUserCourseAsync(userId, courseId);

            var message = result.Message;
            message.Should().Be("");
        }

        [Test]
        public async Task DeleteAsyncWhenUserCoursesReturnSuccess()
        {
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockUserCourseRepository = GetDefaultIUserCourseRepositoryInstance();

            UserCourse userCourse = new UserCourse();
            int courseId = 1, userId = 1;
            userCourse.CourseId = courseId;
            userCourse.UserId = userId;
            mockUserCourseRepository.Setup(r => r.FindByUserIdAndCourseId(userId, courseId))
                .Returns(Task.FromResult<UserCourse>(userCourse));

            var service = new UserCourseService(mockUserCourseRepository.Object,
                mockUnitOfWork.Object);
            UserCourseResponse result = await service.UnassignUserCourseAsync(userId, courseId);

            var message = result.Message;
            message.Should().Be("");
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
        private Mock<IUserCourseRepository> GetDefaultIUserCourseRepositoryInstance()
        {
            return new Mock<IUserCourseRepository>();
        }

    }
}
