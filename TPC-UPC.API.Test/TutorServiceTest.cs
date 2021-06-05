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
        public async Task SaveAsyncWhenTutorReturnsTutor()
        {
            //Arramge
            var mockTutorRepository = GetDefaultITutorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();

            Tutor tutor = new Tutor();
            mockTutorRepository.Setup(r => r.AddAsync(tutor))
                .Returns(Task.FromResult<Tutor>(tutor));

            var service = new TutorService(mockTutorRepository.Object, mockAccountRepository.Object, mockFacultyRepository.Object, mockIUnitOfWork.Object);
            
            // Act
            TutorResponse result = await service.SaveAsync(tutor);
            var message = result.Message;
            
            // Assert
            message.Should().Be("");
        }

        [Test]
        public async Task GetAsyncWhenTutorReturnsTutor()
        {
            // Arrange
            var mockTutorRepository = GetDefaultITutorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();

            Tutor tutor = new Tutor();
            int tutorId = 102;
            tutor.Id = tutorId;
            mockTutorRepository.Setup(r => r.FindById(tutorId))
                .Returns(Task.FromResult<Tutor>(tutor));

            var service = new TutorService(mockTutorRepository.Object,
                mockAccountRepository.Object, mockFacultyRepository.Object, mockIUnitOfWork.Object);

            // Act
            TutorResponse result = await service.GetByIdAsync(tutorId);

            // Assert
            Assert.AreEqual(tutor, result.Resource);
        }

        [Test]
        public async Task DeleteAsyncWhenTutorReturnsTutor()
        {
            // Arrange
            var mockTutorRepository = GetDefaultITutorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();

            Tutor tutor = new Tutor();
            int tutorId = 102;
            tutor.Id = tutorId;

            mockTutorRepository.Setup(r => r.FindById(tutorId))
                .Returns(Task.FromResult<Tutor>(tutor));

            var service = new TutorService(mockTutorRepository.Object, mockAccountRepository.Object, mockFacultyRepository.Object, mockIUnitOfWork.Object);

            // Act
            TutorResponse result = await service.DeleteAsync(tutorId);

            // Assert
            Assert.AreEqual(tutor, result.Resource);
        }

        [Test]
        public async Task PutAsyncWhenTutorsReturnsTutor()
        {
            // Arrange
            var mockTutorRepository = GetDefaultITutorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();

            Tutor tutor = new Tutor();
            int tutorId = 102;
            tutor.Id = tutorId;
            tutor.FirstName = "Jose";

            Tutor tutorExpected = new Tutor();
            tutorExpected.FirstName = "Lucas";

            mockTutorRepository.Setup(r => r.FindById(tutorId))
                .Returns(Task.FromResult<Tutor>(tutor));

            var service = new TutorService(mockTutorRepository.Object, mockAccountRepository.Object, mockFacultyRepository.Object, mockIUnitOfWork.Object);

            // Act
            TutorResponse result = await service.UpdateAsync(tutorId, tutorExpected);

            // Assert
            Assert.AreEqual(tutorExpected.FirstName, result.Resource.FirstName);
        }

        [Test]
        public async Task GetAsyncTestWhenTutorsReturnsNotFoundResponse()
        {
            // Arrange
            var mockTutorRepository = GetDefaultITutorRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();
            int tutorId = 102;

            var service = new TutorService(mockTutorRepository.Object, mockAccountRepository.Object, mockFacultyRepository.Object, mockIUnitOfWork.Object);

            // Act
            TutorResponse result = await service.GetByIdAsync(tutorId);
            var message = result.Message;

            // Assert
            message.Should().Be("Tutor not found");
        }

        private Mock<ITutorRepository> GetDefaultITutorRepositoryInstance()
        {
            return new Mock<ITutorRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
        private Mock<IAccountRepository> GetDefaultIAccountRepositoryInstance()
        {
            return new Mock<IAccountRepository>();
        }

        private Mock<IFacultyRepository> GetDefaultIFacultyRepositoryInstance()
        {
            return new Mock<IFacultyRepository>();
        }
    }
}