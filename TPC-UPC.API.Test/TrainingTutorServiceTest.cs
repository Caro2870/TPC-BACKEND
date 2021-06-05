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
    class TrainingTutorServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenTrainingTutorReturnsTrainingTutor()
        {
            //Arramge
            var mockTrainingTutorRepository = GetDefaultITrainingTutorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            TrainingTutor trainingTutor = new TrainingTutor();
            mockTrainingTutorRepository.Setup(r => r.AddAsync(trainingTutor))
                .Returns(Task.FromResult<TrainingTutor>(trainingTutor));

            var service = new TrainingTutorService(mockTrainingTutorRepository.Object, mockIUnitOfWork.Object);

            // Act
            TrainingTutorResponse result = await service.SaveAsync(trainingTutor);
            var message = result.Message;

            // Assert
            message.Should().Be("");
        }

        [Test]
        public async Task GetAsyncWhenTrainingTutorReturnsTrainingTutor()
        {
            // Arrange
            var mockTrainingTutorRepository = GetDefaultITrainingTutorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            TrainingTutor trainingTutor = new TrainingTutor();
            int trainingId = 2;
            int tutorId = 102;
            trainingTutor.TrainingId = trainingId;
            trainingTutor.TutorId = tutorId;

            mockTrainingTutorRepository.Setup(r => r.FindByTrainingIdAndTutorId(trainingId, tutorId))
                .Returns(Task.FromResult<TrainingTutor>(trainingTutor));

            var service = new TrainingTutorService(mockTrainingTutorRepository.Object, mockIUnitOfWork.Object);

            // Act
            TrainingTutorResponse result = await service.GetById(trainingId, tutorId);

            // Assert
            Assert.AreEqual(trainingTutor, result.Resource);
        }

        [Test]
        public async Task DeleteAsyncWhenTrainingTutorReturnsTrainingTutor()
        {
            // Arrange
            var mockTrainingTutorRepository = GetDefaultITrainingTutorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            TrainingTutor trainingTutor = new TrainingTutor();
            int trainingId = 2;
            int tutorId = 102;
            trainingTutor.TrainingId = trainingId;
            trainingTutor.TutorId = tutorId;

            mockTrainingTutorRepository.Setup(r => r.FindByTrainingIdAndTutorId(trainingId, tutorId))
                .Returns(Task.FromResult<TrainingTutor>(trainingTutor));

            var service = new TrainingTutorService(mockTrainingTutorRepository.Object, mockIUnitOfWork.Object);

            // Act
            TrainingTutorResponse result = await service.DeleteAsync(trainingId, tutorId);

            // Assert
            Assert.AreEqual(trainingTutor, result.Resource);
        }

        [Test]
        public async Task PutAsyncWhenTrainingTutorsReturnsTrainingTutor()
        {
            // Arrange
            var mockTrainingTutorRepository = GetDefaultITrainingTutorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            TrainingTutor trainingTutor = new TrainingTutor();
            int trainingId = 2;
            int tutorId = 102;
            trainingTutor.TrainingId = trainingId;
            trainingTutor.TutorId = tutorId;
            trainingTutor.Assistance = false;

            TrainingTutor trainingTutorExpected = new TrainingTutor();
            trainingTutorExpected.Assistance = true;

            mockTrainingTutorRepository.Setup(r => r.FindByTrainingIdAndTutorId(trainingId, tutorId))
                .Returns(Task.FromResult<TrainingTutor>(trainingTutor));

            var service = new TrainingTutorService(mockTrainingTutorRepository.Object, mockIUnitOfWork.Object);

            // Act
            TrainingTutorResponse result = await service.UpdateAsync(trainingId, tutorId, trainingTutorExpected);

            // Assert
            Assert.AreEqual(trainingTutorExpected.Assistance, result.Resource.Assistance);
        }

        [Test]
        public async Task GetAsyncTestWhenTrainingTutorsReturnsNotFoundResponse()
        {
            // Arrange
            var mockTrainingTutorRepository = GetDefaultITrainingTutorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            int trainingId = 2;
            int tutorId = 102;

            var service = new TrainingTutorService(mockTrainingTutorRepository.Object, mockIUnitOfWork.Object);

            // Act
            TrainingTutorResponse result = await service.GetById(trainingId, tutorId);
            var message = result.Message;

            // Assert
            message.Should().Be("Training tutor not found");
        }

        private Mock<ITrainingTutorRepository> GetDefaultITrainingTutorRepositoryInstance()
        {
            return new Mock<ITrainingTutorRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
