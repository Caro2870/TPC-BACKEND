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
    class LessonServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenLessonReturnsSuccess()
        {
            var mockLessonRepository = GetDefaultILessonRepositoryInstance();
            var mockUnityOfWork = GetDefaultIUnitOfWorkInstance();
            Lesson lesson = new Lesson();
            mockLessonRepository.Setup(r => r.AddAsync(lesson))
                .Returns(Task.FromResult<Lesson>(lesson));
            var service = new LessonService(mockLessonRepository.Object, mockUnityOfWork.Object);
            LessonResponse result = await service.SaveAsync(lesson);
            var message = result.Message;

            message.Should().Be("");
        }

        [Test]
        public async Task GetAsyncGivenAnIdThenReturnsALesson()
        {
            var mockLessonRepository = GetDefaultILessonRepositoryInstance();
            var mockUnityOfWork = GetDefaultIUnitOfWorkInstance();
            var lessonId = 2;
            var mockLesson = new Mock<Lesson>();
            mockLesson.Object.Id = 2;
            mockLesson.Object.Vacants = 3;
            mockLessonRepository.Setup(r => r.FindById(lessonId))
                .Returns(Task.FromResult(mockLesson.Object));

            var service = new LessonService(mockLessonRepository.Object, mockUnityOfWork.Object);
            LessonResponse result = await service.GetByIdAsync(lessonId);
            var id = result.Resource.Id;
            var vacants = result.Resource.Vacants;

            id.Should().Be(2);
            vacants.Should().Be(3);

        }

        private Mock<ILessonRepository> GetDefaultILessonRepositoryInstance()
        {
            return new Mock<ILessonRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
