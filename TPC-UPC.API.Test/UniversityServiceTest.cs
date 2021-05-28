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
        public async Task GetAsyncTestHappy()
        {
            // Arrange
            var mockUniversityRepository = GetDefaultIUniversityRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            University u = new University();
            var universityId = 1;
            u.Id = universityId;

            mockUniversityRepository.Setup(r => r.FindById(universityId))
                .Returns(Task.FromResult<University>(u));

            var service = new UniversityService(mockUniversityRepository.Object, mockIUnitOfWork.Object);

            // Act
            UniversityResponse result = await service.GetByIdAsync(universityId);

            // Assert
            Assert.AreEqual(u,result.Resource);
        }

        [Test]
        public async Task PostAsyncTestHappy()
        {
            // Arrange
            var mockUniversityRepository = GetDefaultIUniversityRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            University u = new University();
            var universityId = 1;
            u.Id = universityId;

            var service = new UniversityService(mockUniversityRepository.Object, mockIUnitOfWork.Object);

            // Act
            UniversityResponse result = await service.SaveAsync(u);

            // Assert
            Assert.AreEqual(u, result.Resource);
        }

        [Test]
        public async Task DeleteAsyncTestHappy()
        {
            // Arrange
            var mockUniversityRepository = GetDefaultIUniversityRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            University u = new University();
            var universityId = 1;
            u.Id = universityId;

            mockUniversityRepository.Setup(r => r.FindById(universityId))
                .Returns(Task.FromResult<University>(u));

            var service = new UniversityService(mockUniversityRepository.Object, mockIUnitOfWork.Object);

            // Act
            UniversityResponse result = await service.DeleteAsync(universityId);

            // Assert
            Assert.AreEqual(u, result.Resource);
        }

        [Test]
        public async Task PutAsyncTest()
        {
            // Arrange
            var mockUniversityRepository = GetDefaultIUniversityRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            University u1 = new University();
            var universityId = 1;
            u1.Id = universityId; u1.UniversityName = "Upc";

            University Uexpected = new University();
            Uexpected.UniversityName = "Universidad de Ingenieria";

            mockUniversityRepository.Setup(r => r.FindById(universityId))
                .Returns(Task.FromResult<University>(u1));

            var service = new UniversityService(mockUniversityRepository.Object, mockIUnitOfWork.Object);

            // Act
            UniversityResponse result = await service.UpdateAsync(universityId,Uexpected);

            // Assert
            Assert.AreEqual(Uexpected.UniversityName, result.Resource.UniversityName);
        }


        [Test]
        public async Task GetAsyncTestUnhappy()
        {
            // Arrange
            var mockUniversityRepository = GetDefaultIUniversityRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var universityId = 1;

            var service = new UniversityService(mockUniversityRepository.Object, mockIUnitOfWork.Object);

            // Act
            UniversityResponse result = await service.GetByIdAsync(universityId);
            var message = result.Message;

            // Assert
            message.Should().Be("University not found");
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