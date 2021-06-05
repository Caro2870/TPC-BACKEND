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
    class StudentServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenStudentsReturnsSuccess()
        {
            //
            var mockStudentRepository = GetDefaultIStudentRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
<<<<<<< HEAD
            var mockCareerRepository = GetDefaultICareerRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();

            Student coordinator = new Student();
            mockStudentRepository.Setup(r => r.AddAsync(coordinator))
                .Returns(Task.FromResult<Student>(coordinator));
            var service = new StudentService(mockStudentRepository.Object,
                mockAccountRepository.Object, mockCareerRepository.Object, mockIUnitOfWork.Object);
            //
            StudentResponse result = await service.SaveAsync(coordinator);
            var message = result.Message;
=======
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();
            var mockCareerRepository = GetDefaultICareerRepositoryInstance();
            Student student = new Student();
            var id = 1;
            student.Id = id;

            mockStudentRepository.Setup(r => r.AddAsync(student))
                .Returns(Task.FromResult<Student>(student));

            var service = new StudentService(mockStudentRepository.Object, mockAccountRepository.Object, 
                mockCareerRepository.Object ,mockIUnitOfWork.Object);
            //
            StudentResponse result = await service.SaveAsync(student);
>>>>>>> feature/businessrulesbri
            //
            Assert.AreEqual(student, result.Resource);
        }

        [Test]
        public async Task GetAsyncTestHappy()
        {
            // Arrange
            var mockStudentRepository = GetDefaultIStudentRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCareerRepository = GetDefaultICareerRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();

            Student coordinator = new Student();
            int coordinatorId = 1;
            coordinator.Id = coordinatorId;
            mockStudentRepository.Setup(r => r.FindById(coordinatorId))
                .Returns(Task.FromResult<Student>(coordinator));

            var service = new StudentService(mockStudentRepository.Object,
                mockAccountRepository.Object, mockCareerRepository.Object, mockIUnitOfWork.Object);

            // Act
            StudentResponse result = await service.GetByIdAsync(coordinatorId);

            // Assert
            Assert.AreEqual(coordinator, result.Resource);
        }

        [Test]
        public async Task DeleteAsyncTestHappy()
        {
            // Arrange
            var mockStudentRepository = GetDefaultIStudentRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCareerRepository = GetDefaultICareerRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();

            Student coordinator = new Student();
            int coordinatorId = 1;
            coordinator.Id = coordinatorId;

            mockStudentRepository.Setup(r => r.FindById(coordinatorId))
                .Returns(Task.FromResult<Student>(coordinator));

            var service = new StudentService(mockStudentRepository.Object,
                mockAccountRepository.Object, mockCareerRepository.Object, mockIUnitOfWork.Object);

            // Act
            StudentResponse result = await service.DeleteAsync(coordinatorId);

            // Assert
            Assert.AreEqual(coordinator, result.Resource);
        }

        [Test]
        public async Task PutAsyncTest()
        {
            // Arrange
            var mockStudentRepository = GetDefaultIStudentRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCareerRepository = GetDefaultICareerRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();

            Student coordinator = new Student();
            int coordinatorId = 1;
            coordinator.Id = coordinatorId;
            coordinator.FirstName = "Ricardo";

            Student coordinatorExpected = new Student();
            coordinatorExpected.FirstName = "William";

            mockStudentRepository.Setup(r => r.FindById(coordinatorId))
                .Returns(Task.FromResult<Student>(coordinator));

            var service = new StudentService(mockStudentRepository.Object,
                mockAccountRepository.Object, mockCareerRepository.Object, mockIUnitOfWork.Object);

            // Act
            StudentResponse result = await service.UpdateASync(coordinatorId, coordinatorExpected);

            // Assert
            Assert.AreEqual(coordinatorExpected.FirstName, result.Resource.FirstName);
        }

        [Test]
        public async Task GetAsyncTestUnhappy()
        {
            // Arrange
            var mockStudentRepository = GetDefaultIStudentRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCareerRepository = GetDefaultICareerRepositoryInstance();
            var mockAccountRepository = GetDefaultIAccountRepositoryInstance();
            int coordinatorId = 1;


            var service = new StudentService(mockStudentRepository.Object,
                mockAccountRepository.Object, mockCareerRepository.Object, mockIUnitOfWork.Object);

            // Act
            StudentResponse result = await service.GetByIdAsync(coordinatorId);
            var message = result.Message;

            // Assert
            message.Should().Be("Student not found");
        }

        private Mock<IStudentRepository> GetDefaultIStudentRepositoryInstance()
        {
            return new Mock<IStudentRepository>();
        }

        private Mock<IAccountRepository> GetDefaultIAccountRepositoryInstance()
        {
            return new Mock<IAccountRepository>();
        }

        private Mock<ICareerRepository> GetDefaultICareerRepositoryInstance()
        {
            return new Mock<ICareerRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
        private Mock<IAccountRepository> GetDefaultIAccountRepositoryInstance()
        {
            return new Mock<IAccountRepository>();
        }

        private Mock<ICareerRepository> GetDefaultICareerRepositoryInstance()
        {
            return new Mock<ICareerRepository>();
        }
    }
}
