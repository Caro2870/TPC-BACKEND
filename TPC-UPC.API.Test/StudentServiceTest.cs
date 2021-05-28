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
            Student student = new Student();
            mockStudentRepository.Setup(r => r.AddAsync(student))
                .Returns(Task.FromResult<Student>(student));

            var service = new StudentService(mockStudentRepository.Object,  mockIUnitOfWork.Object);
            //
            StudentResponse result = await service.SaveAsync(student);
            var message = result.Message;
            //
            message.Should().Be("");
        }

        private Mock<IStudentRepository> GetDefaultIStudentRepositoryInstance()
        {
            return new Mock<IStudentRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
