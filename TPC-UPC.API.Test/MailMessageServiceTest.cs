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
    class MailMessageServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

        private Mock<IMailMessageRepository> GetDefaultIMailMessageRepositoryInstance()
        {
            return new Mock<IMailMessageRepository>();
        }

        private Mock<ICoordinatorRepository> GetDefaultICoordinatorRepositoryInstance()
        {
            return new Mock<ICoordinatorRepository>();
        }

        [Test]
        public async Task GetAsyncTestHappy()
        {
            // Arrange
            var mockMailMessageRepository = GetDefaultIMailMessageRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();

            MailMessage mailMessage = new MailMessage();
            var mailMessageId = 1;
            mailMessage.Id = mailMessageId;

            mockMailMessageRepository.Setup(r => r.FindById(mailMessageId))
                .Returns(Task.FromResult<MailMessage>(mailMessage));

            var service = new MailMessageService(mockMailMessageRepository.Object, mockCoordinatorRepository.Object, mockIUnitOfWork.Object);

            // Act
            MailMessageResponse result = await service.GetByIdAsync(mailMessageId);

            // Assert
            Assert.AreEqual(mailMessage, result.Resource);
        }

        [Test]
        public async Task PostAsyncTestHappy()
        {
            // Arrange
            var mockMailMessageRepository = GetDefaultIMailMessageRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();

            MailMessage mailMessage = new MailMessage();
            var mailMessageId = 1;
            mailMessage.Id = mailMessageId;

            var service = new MailMessageService(mockMailMessageRepository.Object, mockCoordinatorRepository.Object, mockIUnitOfWork.Object);

            // Act
            MailMessageResponse result = await service.SaveAsync(mailMessage, 1);

            // Assert
            var message = result.Message;
            message.Should().Be("");
        }

        [Test]
        public async Task DeleteAsyncTestHappy()
        {
            // Arrange
            var mockMailMessageRepository = GetDefaultIMailMessageRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();

            MailMessage mailMessage = new MailMessage();
            var mailMessageId = 1;
            mailMessage.Id = mailMessageId;
            mailMessage.CoordinatorId = 1;

            mockMailMessageRepository.Setup(r => r.FindById(mailMessageId))
                .Returns(Task.FromResult<MailMessage>(mailMessage));

            var service = new MailMessageService(mockMailMessageRepository.Object, mockCoordinatorRepository.Object, mockIUnitOfWork.Object);

            // Act
            MailMessageResponse result = await service.DeleteAsync(mailMessageId, 1);

            // Assert
            Assert.AreEqual(mailMessage, result.Resource);
        }

        [Test]
        public async Task PutAsyncTest()
        {
            // Arrange
            var mockMailMessageRepository = GetDefaultIMailMessageRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();

            Coordinator coordinator = new Coordinator();
            int coordinatorId = 1;
            coordinator.Id = coordinatorId;

            MailMessage mailMessage = new MailMessage();
            var mailMessageId = 1;
            mailMessage.Id = mailMessageId;
            mailMessage.CoordinatorId = coordinatorId;
            mailMessage.DocumentLink = "drive.sem5";

            MailMessage mailMessageExpected = new MailMessage();
            mailMessageExpected.CoordinatorId = 1;
            mailMessageExpected.DocumentLink = "mega.sem5";

            

            mockMailMessageRepository.Setup(r => r.FindById(mailMessageId))
                .Returns(Task.FromResult<MailMessage>(mailMessage));

            mockCoordinatorRepository.Setup(r => r.FindById(coordinatorId))
                .Returns(Task.FromResult<Coordinator>(coordinator));

            var service = new MailMessageService(mockMailMessageRepository.Object, mockCoordinatorRepository.Object, mockIUnitOfWork.Object);

            // Act
            MailMessageResponse result = await service.UpdateASync(mailMessageId, mailMessage.CoordinatorId , mailMessageExpected);

            // Assert
            Assert.AreEqual(mailMessageExpected.DocumentLink, result.Resource.DocumentLink);
        }


        [Test]
        public async Task GetAsyncTestUnhappy()
        {
            // Arrange
            var mockMailMessageRepository = GetDefaultIMailMessageRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockCoordinatorRepository = GetDefaultICoordinatorRepositoryInstance();

            var mailMessageId = 1;
            var service = new MailMessageService(mockMailMessageRepository.Object, mockCoordinatorRepository.Object, mockIUnitOfWork.Object);

            // Act
            MailMessageResponse result = await service.GetByIdAsync(mailMessageId);
            var message = result.Message;

            // Assert
            message.Should().Be("mail message not found");
        }
    }
}
