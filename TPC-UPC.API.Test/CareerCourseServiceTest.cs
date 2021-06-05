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
    class CareerCourseServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenCareerCoursesReturnSuccess()
        {
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCareerCourseRepository = GetDefaultICareerCourseRepositoryInstance();

            CareerCourse careerCourse = new CareerCourse();
            int courseId = 1, careerId = 1;
            careerCourse.CourseId = courseId;
            careerCourse.CareerId = careerId;
            mockCareerCourseRepository.Setup(r => r.AssignCareerCourse(careerId, courseId))
                .Returns(Task.FromResult<CareerCourse>(careerCourse));

            var service = new CareerCourseService(mockCareerCourseRepository.Object,
                mockUnitOfWork.Object);
            CareerCourseResponse result = await service.AssignCareerCourseAsync(careerId, courseId);

            var message = result.Message;
            message.Should().Be("");
        }

        [Test]
        public async Task DeleteAsyncWhenCareerCoursesReturnSuccess()
        {
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCareerCourseRepository = GetDefaultICareerCourseRepositoryInstance();

            CareerCourse careerCourse = new CareerCourse();
            int courseId = 1, careerId = 1;
            careerCourse.CourseId = courseId;
            careerCourse.CareerId = careerId;
            mockCareerCourseRepository.Setup(r => r.FindByCareerIdAndCourseId(careerId, courseId))
                .Returns(Task.FromResult<CareerCourse>(careerCourse));

            var service = new CareerCourseService(mockCareerCourseRepository.Object,
                mockUnitOfWork.Object);
            CareerCourseResponse result = await service.UnassignCareerCourseAsync(careerId, courseId);

            var message = result.Message;
            message.Should().Be("");
        }
        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
        private Mock<ICareerCourseRepository> GetDefaultICareerCourseRepositoryInstance()
        {
            return new Mock<ICareerCourseRepository>();
        }

    }
}
