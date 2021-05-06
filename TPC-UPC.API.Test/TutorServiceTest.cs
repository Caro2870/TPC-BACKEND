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
    class TutorServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenUniversitiesReturnsSuccess()
        {
            //
            var mockTutorRepository = GetDefaultITutorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Tutor tutor = new Tutor();
            mockTutorRepository.Setup(r => r.AddAsync(tutor))
                .Returns(Task.FromResult<Tutor>(tutor));
            var service = new TutorService(mockTutorRepository.Object, mockIUnitOfWork.Object);
            //
            TutorResponse result = await service.SaveAsync(tutor);
            var message = result.Message;
            //
            message.Should().Be("");
        }

        private Mock<ITutorRepository> GetDefaultITutorRepositoryInstance()
        {
            return new Mock<ITutorRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
