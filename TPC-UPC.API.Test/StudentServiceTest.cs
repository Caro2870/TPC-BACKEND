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
            //
            Assert.AreEqual(student, result.Resource);
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
    }
}
