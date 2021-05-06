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
    class CareerServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenUniversitiesReturnsSuccess()
        {
            //
            var mockCareerRepository = GetDefaultICareerRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Career career = new Career();
            mockCareerRepository.Setup(r => r.AddAsync(career))
                .Returns(Task.FromResult<Career>(career));
            var service = new CareerService(mockCareerRepository.Object, mockIUnitOfWork.Object);
            //
            CarrerResponse result = await service.SaveAsync(career);
            var message = result.Message;
            //
            message.Should().Be("");
        }

        private Mock<ICareerRepository> GetDefaultICareerRepositoryInstance()
        {
            return new Mock<ICareerRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
