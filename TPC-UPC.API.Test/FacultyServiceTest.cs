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
        public async Task SaveAsyncWhenFacultiesReturnsSuccess()
        {
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockUniversityRepository = GetDefaultIUniversityRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Faculty faculty = new Faculty();
            mockFacultyRepository.Setup(r => r.AddAsync(faculty))
                .Returns(Task.FromResult<Faculty>(faculty));
            var service = new FacultyService(mockFacultyRepository.Object, mockUniversityRepository.Object, mockUnitOfWork.Object);
            FacultyResponse result = await service.SaveAsync(faculty, 1);
            var message = result.Message;

            message.Should().Be("");
        }

        [Test]
        public async Task GetAsyncTestHappy()
        {
            // Arrange
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockUniversityRepository = GetDefaultIUniversityRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Faculty faculty = new Faculty();
            int facultyId = 1;
            faculty.Id = facultyId;
            mockFacultyRepository.Setup(r => r.FindById(facultyId))
                .Returns(Task.FromResult<Faculty>(faculty));

            var service = new FacultyService(mockFacultyRepository.Object, mockUniversityRepository.Object, mockUnitOfWork.Object);

            // Act
            FacultyResponse result = await service.GetByIdAsync(facultyId);

            // Assert
            Assert.AreEqual(faculty, result.Resource);
        }
        [Test]
        public async Task DeleteAsyncTestHappy()
        {
            // Arrange
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockUniversityRepository = GetDefaultIUniversityRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Faculty faculty = new Faculty();
            int facultyId = 1;
            faculty.Id = facultyId;

            mockFacultyRepository.Setup(r => r.FindById(facultyId))
                .Returns(Task.FromResult<Faculty>(faculty));

            var service = new FacultyService(mockFacultyRepository.Object, mockUniversityRepository.Object, mockUnitOfWork.Object);

            // Act
            FacultyResponse result = await service.DeleteAsync(facultyId);

            // Assert
            Assert.AreEqual(faculty, result.Resource);
        }

        [Test]
        public async Task PutAsyncTest()
        {
            // Arrange
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockUniversityRepository = GetDefaultIUniversityRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Faculty faculty = new Faculty();
            int facultyId = 1;
            faculty.Id = facultyId;
            faculty.Name = "Ciencias";

            Faculty facultyExpected = new Faculty();
            facultyExpected.Name = "Letras";

            mockFacultyRepository.Setup(r => r.FindById(facultyId))
                .Returns(Task.FromResult<Faculty>(faculty));

            var service = new FacultyService(mockFacultyRepository.Object, mockUniversityRepository.Object, mockUnitOfWork.Object);

            // Act
            FacultyResponse result = await service.UpdateASync(facultyId, facultyExpected);

            // Assert
            Assert.AreEqual(facultyExpected.Name, result.Resource.Name);
        }


        [Test]
        public async Task GetAsyncTestUnhappy()
        {
            // Arrange
            var mockFacultyRepository = GetDefaultIFacultyRepositoryInstance();
            var mockUniversityRepository = GetDefaultIUniversityRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            int facultyId = 1;


            var service = new FacultyService(mockFacultyRepository.Object, mockUniversityRepository.Object, mockUnitOfWork.Object);

            // Act
            FacultyResponse result = await service.GetByIdAsync(facultyId);
            var message = result.Message;

            // Assert
            message.Should().Be("Faculty not found");
        }

        private Mock<IFacultyRepository> GetDefaultIFacultyRepositoryInstance()
        {
            return new Mock<IFacultyRepository>();
        }

        private Mock<IUniversityRepository> GetDefaultIUniversityRepositoryInstance()
        {
            return new Mock<IUniversityRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
