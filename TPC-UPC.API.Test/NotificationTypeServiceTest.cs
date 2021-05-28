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
    class NotificationTypeServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetAsyncTestHappy()
        {
            // Arrange
            var mockNotificationTypeRepository = GetDefaultINotificationTypeRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            NotificationType nt = new NotificationType();
            var notificationTypeId = 1;
            nt.Id = notificationTypeId;

            mockNotificationTypeRepository.Setup(r => r.FindById(notificationTypeId))
                .Returns(Task.FromResult<NotificationType>(nt));

            var service = new NotificationTypeService(mockNotificationTypeRepository.Object, mockIUnitOfWork.Object);

            // Act
            NotificationTypeResponse result = await service.GetByIdAsync(notificationTypeId);

            // Assert
            Assert.AreEqual(nt, result.Resource);
        }

        [Test]
        public async Task PostAsyncTestHappy()
        {
            // Arrange
            var mockNotificationTypeRepository = GetDefaultINotificationTypeRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            NotificationType nt = new NotificationType();
            var notificationTypeId = 1;
            nt.Id = notificationTypeId;

            var service = new NotificationTypeService(mockNotificationTypeRepository.Object, mockIUnitOfWork.Object);

            // Act
            NotificationTypeResponse result = await service.SaveAsync(nt);

            // Assert
            Assert.AreEqual(nt, result.Resource);
        }

        [Test]
        public async Task DeleteAsyncTestHappy()
        {
            // Arrange
            var mockNotificationTypeRepository = GetDefaultINotificationTypeRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            NotificationType nt = new NotificationType();
            var notificationTypeId = 1;
            nt.Id = notificationTypeId;

            mockNotificationTypeRepository.Setup(r => r.FindById(notificationTypeId))
                .Returns(Task.FromResult<NotificationType>(nt));

            var service = new NotificationTypeService(mockNotificationTypeRepository.Object, mockIUnitOfWork.Object);

            // Act
            NotificationTypeResponse result = await service.DeleteAsync(notificationTypeId);

            // Assert
            Assert.AreEqual(nt, result.Resource);
        }

        [Test]
        public async Task PutAsyncTest()
        {
            // Arrange
            var mockNotificationTypeRepository = GetDefaultINotificationTypeRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            NotificationType nt = new NotificationType();
            var notificationTypeId = 1;
            nt.Id = notificationTypeId; nt.Description = "Announcement: 30 minutes to start the class";

            NotificationType expected = new NotificationType();
            expected.Description = "Announcement out of date";

            mockNotificationTypeRepository.Setup(r => r.FindById(notificationTypeId))
                .Returns(Task.FromResult<NotificationType>(nt));

            var service = new NotificationTypeService(mockNotificationTypeRepository.Object, mockIUnitOfWork.Object);

            // Act
            NotificationTypeResponse result = await service.UpdateAsync(notificationTypeId,expected);

            // Assert
            Assert.AreEqual(expected.Description, result.Resource.Description);
        }

        [Test]
        public async Task GetAsyncTestUnhappy()
        {
            // Arrange
            var mockNotificationTypeRepository = GetDefaultINotificationTypeRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var notificationTypeId = 1;

            var service = new NotificationTypeService(mockNotificationTypeRepository.Object, mockIUnitOfWork.Object);

            // Act
            NotificationTypeResponse result = await service.GetByIdAsync(notificationTypeId);
            var message = result.Message;

            // Assert
            message.Should().Be("Notification type not found");
        }

        private Mock<INotificationTypeRepository> GetDefaultINotificationTypeRepositoryInstance()
        {
            return new Mock<INotificationTypeRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
