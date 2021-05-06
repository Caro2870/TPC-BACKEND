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
    class FacultyServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenUniversitiesReturnsSuccess()
        {
            //
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Faculty faculty = new Faculty();
            mockFacultyRepository.Setup(r => r.AddAsync(faculty))
                .Returns(Task.FromResult<Faculty>(faculty));
            var service = new FacultyService(mockFacultyRepository.Object, mockIUnitOfWork.Object);
            //
            FacultyResponse result = await service.SaveAsync(faculty);
            var message = result.Message;
            //
            message.Should().Be("");
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
