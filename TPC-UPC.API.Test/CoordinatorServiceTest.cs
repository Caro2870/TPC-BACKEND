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
    /*class CoordinatorServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenCoordinatorsReturnsSuccess()
        {
            //
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();

            Coordinator coordinator = new Coordinator();
            mockCoordinatorRepository.Setup(r => r.AddAsync(coordinator))
                .Returns(Task.FromResult<Coordinator>(coordinator));
            var service = new CoordinatorService(mockCoordinatorRepository.Object, 
                mockAccountRepository.Object , mockFacultyRepository.Object, mockIUnitOfWork.Object);
            //
            CoordinatorResponse result = await service.SaveAsync(coordinator);
            var message = result.Message;
            //
            message.Should().Be("");
        }

        [Test]
        public async Task GetAsyncTestHappy()
        {
            // Arrange
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();

            Coordinator coordinator = new Coordinator();
            int coordinatorId = 1;
            coordinator.Id = coordinatorId;
            mockCoordinatorRepository.Setup(r => r.FindById(coordinatorId))
                .Returns(Task.FromResult<Coordinator>(coordinator));

            var service = new CoordinatorService(mockCoordinatorRepository.Object,
                mockAccountRepository.Object, mockFacultyRepository.Object, mockIUnitOfWork.Object);

            // Act
            CoordinatorResponse result = await service.GetByIdAsync(coordinatorId);

            // Assert
            Assert.AreEqual(coordinator, result.Resource);
        }

        [Test]
        public async Task DeleteAsyncTestHappy()
        {
            // Arrange
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();

            Coordinator coordinator = new Coordinator();
            int coordinatorId = 1;
            coordinator.Id = coordinatorId;

            mockCoordinatorRepository.Setup(r => r.FindById(coordinatorId))
                .Returns(Task.FromResult<Coordinator>(coordinator));

            var service = new CoordinatorService(mockCoordinatorRepository.Object,
                mockAccountRepository.Object, mockFacultyRepository.Object, mockIUnitOfWork.Object);

            // Act
            CoordinatorResponse result = await service.DeleteAsync(coordinatorId);

            // Assert
            Assert.AreEqual(coordinator, result.Resource);
        }

        [Test]
        public async Task PutAsyncTest()
        {
            // Arrange
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();

            Coordinator coordinator = new Coordinator();
            int coordinatorId = 1;
            coordinator.Id = coordinatorId;
            coordinator.FirstName = "Ricardo";

            Coordinator coordinatorExpected = new Coordinator();
            coordinatorExpected.FirstName = "William";

            mockCoordinatorRepository.Setup(r => r.FindById(coordinatorId))
                .Returns(Task.FromResult<Coordinator>(coordinator));

            var service = new CoordinatorService(mockCoordinatorRepository.Object,
                mockAccountRepository.Object, mockFacultyRepository.Object, mockIUnitOfWork.Object);

            // Act
            CoordinatorResponse result = await service.UpdateASync(coordinatorId, coordinatorExpected);

            // Assert
            Assert.AreEqual(coordinatorExpected.FirstName, result.Resource.FirstName);
        }

        [Test]
        public async Task GetAsyncTestUnhappy()
        {
            // Arrange
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();
            int coordinatorId = 1;


            var service = new CoordinatorService(mockCoordinatorRepository.Object,
                mockAccountRepository.Object, mockFacultyRepository.Object, mockIUnitOfWork.Object);

            // Act
            CoordinatorResponse result = await service.GetByIdAsync(coordinatorId);
            var message = result.Message;

            // Assert
            message.Should().Be("Coordinator not found");
        }

        private Mock<ICoordinatorRepository> GetDefaultICoordinatorRepositoryInstance()
        {
            return new Mock<ICoordinatorRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
<<<<<<< HEAD
        private Mock<IAccountRepository> GetDefaultIAccountRepositoryInstance()
        {
            return new Mock<IAccountRepository>();
        }

        private Mock<IFacultyRepository> GetDefaultIFacultyRepositoryInstance()
        {
            return new Mock<IFacultyRepository>();
        }
    }
=======
    }*/
>>>>>>> feature/businessrules-rodrigo
}
