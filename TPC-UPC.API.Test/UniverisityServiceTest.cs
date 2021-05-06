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
    public class UniversityServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenUniversitiesReturnsSuccess()
        {
            //
            var mockUniversityRepository = GetDefaultIUniversityRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            University university = new University();
            mockUniversityRepository.Setup(r => r.AddAsync(university))
                .Returns( Task.FromResult<University>(university));
            var service = new UniversityService(mockUniversityRepository.Object, mockIUnitOfWork.Object);
            //
            UniversityResponse result = await service.SaveAsync(university);
            var message = result.Message;
            //
            message.Should().Be("");
        }

        private Mock<IUniversityRepository> GetDefaultIUniversityRepositoryInstance ()
        {
            return new Mock<IUniversityRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}