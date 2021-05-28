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


        [Test]
        public async Task GetAsyncTestHappy()
        {
            // Arrange
            var mockCareerRepository = GetDefaultICareerRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var careerId = 1;
            Career career = new Career();
          

            mockCareerRepository.Setup(r => r.FindById(careerId))
                .Returns(Task.FromResult<Career>(career));

            var service = new CareerService(mockCareerRepository.Object, mockFacultyRepository.Object,mockIUnitOfWork.Object);

            // Act
            CareerResponse result = await service.GetByIdAsync(careerId);

            // Assert
            Assert.AreEqual(career, result.Resource);
        }

        [Test]
        public async Task PostAsyncTestHappy()
        {
            // Arrange
            var mockCareerRepository = GetDefaultICareerRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var careerId = 1;
            var facultyId = 1;
            Career career = new Career();
            career.Id = careerId;
            Faculty faculty = new Faculty();
            faculty.Id = facultyId;

            var service = new CareerService(mockCareerRepository.Object, mockFacultyRepository.Object, mockIUnitOfWork.Object);

            // Act
            CareerResponse result = await service.SaveAsync(career,facultyId);

            // Assert
            Assert.AreEqual(career, result.Resource);
        }

        [Test]
        public async Task DeleteAsyncTestHappy()
        {
            // Arrange
            var mockCareerRepository = GetDefaultICareerRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var careerId = 1;
            Career career = new Career();
            career.Id = careerId;

            mockCareerRepository.Setup(r => r.FindById(careerId))
                .Returns(Task.FromResult<Career>(career));

            var service = new CareerService(mockCareerRepository.Object, mockFacultyRepository.Object, mockIUnitOfWork.Object);

            // Act
            CareerResponse result = await service.DeleteAsync(careerId);

            // Assert
            Assert.AreEqual(career, result.Resource);
        }

        [Test]
        public async Task PutAsyncTest()
        {
            // Arrange
            var mockCareerRepository = GetDefaultICareerRepositoryInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
          
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var careerId = 1;
            Career a = new Career();
            a.Id = careerId; a.CareerName = "software"; 

            Career expected = new Career();
            expected.CareerName = "sistemsa"; 

            mockCareerRepository.Setup(r => r.FindById(careerId))
                .Returns(Task.FromResult<Career>(a));

            var service = new CareerService(mockCareerRepository.Object, mockFacultyRepository.Object, mockIUnitOfWork.Object);

            // Act
            CareerResponse result = await service.UpdateASync(careerId, expected);

            // Assert
            Assert.AreEqual(expected.CareerName, result.Resource.CareerName);
        }



        [Test]
        public async Task GetAsyncTestUnhappy()
        {
            // Arrange
            var mockCareerRepository = GetDefaultICareerRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            Career career = new Career();
            var careerId = 1;
            career.Id = careerId;

            var service = new CareerService(mockCareerRepository.Object, mockFacultyRepository.Object, mockIUnitOfWork.Object);

            // Act
            CareerResponse result = await service.GetByIdAsync(careerId);
            var message = result.Message;

            // Assert
            Assert.AreEqual(null, result.Resource);
            message.Should().Be("Career not found");
        }

        private Mock<ICareerRepository> GetDefaultICareerRepositoryInstance()
        {
            return new Mock<ICareerRepository>();
        }

        private Mock<IFacultyRepository> GetDefaultIFacultyRepositoryInstance()
        {
            return new Mock<IFacultyRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}