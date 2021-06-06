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
    class SuggestionServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenFacultiesReturnsSuccess()
        {
            var mockSuggestionRepository = GetDefaultISuggestionRepositoryInstance();
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Suggestion suggestion = new Suggestion();
            mockSuggestionRepository.Setup(r => r.AddAsync(suggestion))
                .Returns(Task.FromResult<Suggestion>(suggestion));
            var service = new SuggestionService(mockSuggestionRepository.Object, 
                mockUnitOfWork.Object, mockUserRepository.Object);
            SuggestionResponse result = await service.SaveAsync(suggestion);
            var message = result.Message;

            message.Should().Be("");
        }

        [Test]
        public async Task GetAsyncTestHappy()
        {
            // Arrange
            var mockSuggestionRepository = GetDefaultISuggestionRepositoryInstance();
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Suggestion suggestion = new Suggestion();
            int suggestionId = 1;
            suggestion.Id = suggestionId;
            mockSuggestionRepository.Setup(r => r.FindById(suggestionId))
                .Returns(Task.FromResult<Suggestion>(suggestion));

            var service = new SuggestionService(mockSuggestionRepository.Object,
                mockUnitOfWork.Object, mockUserRepository.Object);

            // Act
            SuggestionResponse result = await service.GetByIdAsync(suggestionId);

            // Assert
            Assert.AreEqual(suggestion, result.Resource);
        }

        [Test]
        public async Task DeleteAsyncTestHappy()
        {
            // Arrange
            var mockSuggestionRepository = GetDefaultISuggestionRepositoryInstance();
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Suggestion suggestion = new Suggestion();
            int suggestionId = 1;
            suggestion.Id = suggestionId;

            mockSuggestionRepository.Setup(r => r.FindById(suggestionId))
                .Returns(Task.FromResult<Suggestion>(suggestion));

            var service = new SuggestionService(mockSuggestionRepository.Object,
                mockUnitOfWork.Object, mockUserRepository.Object);

            // Act
            SuggestionResponse result = await service.DeleteAsync(suggestionId);

            // Assert
            Assert.AreEqual(suggestion, result.Resource);
        }

        [Test]
        public async Task PutAsyncTest()
        {
            // Arrange
            var mockSuggestionRepository = GetDefaultISuggestionRepositoryInstance();
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Suggestion suggestion = new Suggestion();
            int suggestionId = 1;
            suggestion.Id = suggestionId;
            suggestion.Message = "mejorar";

            Suggestion suggestionExpected = new Suggestion();
            suggestionExpected.Message = "es bueno";

            mockSuggestionRepository.Setup(r => r.FindById(suggestionId))
                .Returns(Task.FromResult<Suggestion>(suggestion));

            var service = new SuggestionService(mockSuggestionRepository.Object,
                mockUnitOfWork.Object, mockUserRepository.Object);

            // Act
            SuggestionResponse result = await service.UpdateASync(suggestionId, suggestionExpected );

            // Assert
            Assert.AreEqual(suggestionExpected.Message, result.Resource.Message);
        }

        [Test]
        public async Task GetAsyncTestUnhappy()
        {
            // Arrange
            var mockSuggestionRepository = GetDefaultISuggestionRepositoryInstance();
            var mockUserRepository = GetDefaultIUserRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            int suggestionId = 1;

            var service = new SuggestionService(mockSuggestionRepository.Object,
                mockUnitOfWork.Object, mockUserRepository.Object);

            // Act
            SuggestionResponse result = await service.GetByIdAsync(suggestionId);
            var message = result.Message;

            // Assert
            message.Should().Be("Suggestion not found");
        }

        private Mock<ISuggestionRepository> GetDefaultISuggestionRepositoryInstance()
        {
            return new Mock<ISuggestionRepository>();
        }

        private Mock<IUserRepository> GetDefaultIUserRepositoryInstance()
        {
            return new Mock<IUserRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

    }
}
