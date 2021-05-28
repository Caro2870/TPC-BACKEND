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
    class NotificationServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAsyncTestHappy()
        {
            // Arrange
            var mockNotificationRepository = GetDefaultINotificationRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var notificationId = 1;
            Notification n = new Notification();
            //a.Id = accountId;
            //a.AccountName = "rodrigo"; a.Password = "1234567890";

            mockNotificationRepository.Setup(r => r.FindById(notificationId))
                .Returns(Task.FromResult<Notification>(n));

            var service = new NotificationService(mockNotificationRepository.Object, mockIUnitOfWork.Object);

            // Act
            NotificationResponse result = await service.GetByIdAsync(notificationId);

            // Assert
            Assert.AreEqual(n, result.Resource);
        }

        [Test]
        public async Task PostAsyncTestHappy()
        {
            // Arrange
            var mockNotificationRepository = GetDefaultINotificationRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var notificationId = 1;
            Notification n = new Notification();
            n.Id = notificationId;

            var service = new NotificationService(mockNotificationRepository.Object, mockIUnitOfWork.Object);

            // Act
            NotificationResponse result = await service.SaveAsync(n);

            // Assert
            Assert.AreEqual(n, result.Resource);
        }

        [Test]
        public async Task DeleteAsyncTestHappy()
        {
            // Arrange
            var mockNotificationRepository = GetDefaultINotificationRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var notificationId = 1;
            Notification n = new Notification();
            n.Id = notificationId;

            mockNotificationRepository.Setup(r => r.FindById(notificationId))
                .Returns(Task.FromResult<Notification>(n));

            var service = new NotificationService(mockNotificationRepository.Object, mockIUnitOfWork.Object);

            // Act
            NotificationResponse result = await service.DeleteAsync(notificationId);

            // Assert
            Assert.AreEqual(n, result.Resource);
        }

        [Test]
        public async Task PutAsyncTest()
        {
            // Arrange
            var mockNotificationRepository = GetDefaultINotificationRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var notificationId = 1;
            Notification n = new Notification();
            n.Id = notificationId; n.Link = "google.com"; n.NotificationTypeId = 1; n.SendDate = new DateTime(2018, 5, 10);
            n.NotificationTypeId = 1;

            Notification expected = new Notification();
            expected.Id = notificationId; expected.Link = "meet.es"; 
            expected.SendDate = new DateTime(2019, 7, 23); expected.NotificationTypeId = 2;

            mockNotificationRepository.Setup(r => r.FindById(notificationId))
                .Returns(Task.FromResult<Notification>(n));

            var service = new NotificationService(mockNotificationRepository.Object, mockIUnitOfWork.Object);

            // Act
            NotificationResponse result = await service.UpdateAsync(notificationId, expected);

            // Assert
            Assert.AreEqual(expected.Id, result.Resource.Id);
            Assert.AreEqual(expected.Link, result.Resource.Link);
            Assert.AreEqual(expected.SendDate, result.Resource.SendDate);
            Assert.AreEqual(expected.NotificationTypeId, result.Resource.NotificationTypeId);
        }




        [Test]
        public async Task GetAsyncTestUnhappy()
        {
            // Arrange
            var mockNotificationRepository = GetDefaultINotificationRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();

            var notificationId = 1;
            Notification n = new Notification();
            n.Id = notificationId; n.Link = "google.com"; n.NotificationTypeId = 1; n.SendDate = new DateTime(2018, 5, 10);
            n.NotificationTypeId = 1;

            var service = new NotificationService(mockNotificationRepository.Object, mockIUnitOfWork.Object);

            // Act
            NotificationResponse result = await service.GetByIdAsync(notificationId);
            var message = result.Message;

            // Assert
            Assert.AreEqual(null, result.Resource);
            message.Should().Be("Notification not found");
        }


        private Mock<INotificationRepository> GetDefaultINotificationRepositoryInstance()
        {
            return new Mock<INotificationRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
