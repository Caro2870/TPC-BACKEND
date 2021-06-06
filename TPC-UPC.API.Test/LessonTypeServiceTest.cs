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
    class LessonTypeServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenLessonTypeReturnsSuccess()
        {
            var mockLessonTypeRepository = GetDefaultILessonTypeRepositoryInstance();
            var mockUnityOfWork = GetDefaultIUnitOfWorkInstance();
            LessonType lessonType = new LessonType();
            lessonType.LessonTypeName = "Tutoria";
            mockLessonTypeRepository.Setup(r => r.AddAsync(lessonType))
                .Returns(Task.FromResult<LessonType>(lessonType));
            var service = new LessonTypeService(mockLessonTypeRepository.Object, mockUnityOfWork.Object);
            LessonTypeResponse result = await service.SaveAsync(lessonType);
            var typename = result.Resource.LessonTypeName;
            typename.Should().Be("Tutoria");
        }

        private Mock<ILessonTypeRepository> GetDefaultILessonTypeRepositoryInstance()
        {
            return new Mock<ILessonTypeRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
