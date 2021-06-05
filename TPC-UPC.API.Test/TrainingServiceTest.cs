using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Services;

namespace TPC_UPC.API.Test
{
    class TrainingServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenTrainingReturnsTraining()
        {
            //Arramge
            var mockTrainingRepository = GetDefaultITrainingRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();

            Training training = new Training();
            mockTrainingRepository.Setup(r => r.AddAsync(training))
                .Returns(Task.FromResult<Training>(training));

            var service = new TrainingService(mockTrainingRepository.Object, mockIUnitOfWork.Object, mockCoordinatorRepository.Object);

            // Act
            TrainingResponse result = await service.SaveAsync(training);
            var message = result.Message;

            // Assert
            message.Should().Be("");
        }

        [Test]
        public async Task GetAsyncWhenTrainingReturnsTraining()
        {
            // Arrange
            var mockTrainingRepository = GetDefaultITrainingRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();

            Training training = new Training();
            int trainingId = 102;
            training.Id = trainingId;
            mockTrainingRepository.Setup(r => r.FindById(trainingId))
                .Returns(Task.FromResult<Training>(training));

            var service = new TrainingService(mockTrainingRepository.Object, mockIUnitOfWork.Object, mockCoordinatorRepository.Object);

            // Act
            TrainingResponse result = await service.GetByIdAsync(trainingId);

            // Assert
            Assert.AreEqual(training, result.Resource);
        }

        [Test]
        public async Task DeleteAsyncWhenTrainingReturnsTraining()
        {
            // Arrange
            var mockTrainingRepository = GetDefaultITrainingRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();

            Training training = new Training();
            int trainingId = 102;
            training.Id = trainingId;

            mockTrainingRepository.Setup(r => r.FindById(trainingId))
                .Returns(Task.FromResult<Training>(training));

            var service = new TrainingService(mockTrainingRepository.Object, mockIUnitOfWork.Object, mockCoordinatorRepository.Object);

            // Act
            TrainingResponse result = await service.DeleteAsync(trainingId);

            // Assert
            Assert.AreEqual(training, result.Resource);
        }

        [Test]
        public async Task PutAsyncWhenTrainingsReturnsTraining()
        {
            // Arrange
            var mockTrainingRepository = GetDefaultITrainingRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();

            Training training = new Training();
            int trainingId = 102;
            training.Id = trainingId;
            training.Description = "Primera reunión";

            Training trainingExpected = new Training();
            trainingExpected.Description = "Reunión de bienvenida";

            mockTrainingRepository.Setup(r => r.FindById(trainingId))
                .Returns(Task.FromResult<Training>(training));

            var service = new TrainingService(mockTrainingRepository.Object, mockIUnitOfWork.Object, mockCoordinatorRepository.Object);

            // Act
            TrainingResponse result = await service.UpdateAsync(trainingId, trainingExpected);

            // Assert
            Assert.AreEqual(trainingExpected.Description, result.Resource.Description);
        }

        [Test]
        public async Task GetAsyncTestWhenTrainingsReturnsNotFoundResponse()
        {
            // Arrange
            var mockTrainingRepository = GetDefaultITrainingRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();

            int trainingId = 102;

            var service = new TrainingService(mockTrainingRepository.Object, mockIUnitOfWork.Object, mockCoordinatorRepository.Object);

            // Act
            TrainingResponse result = await service.GetByIdAsync(trainingId);
            var message = result.Message;

            // Assert
            message.Should().Be("Training not found");
        }

        private Mock<ITrainingRepository> GetDefaultITrainingRepositoryInstance()
        {
            return new Mock<ITrainingRepository>();
        }

        private Mock<ICoordinatorRepository> GetDefaultICoordinatorRepositoryInstance()
        {
            return new Mock<ICoordinatorRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
