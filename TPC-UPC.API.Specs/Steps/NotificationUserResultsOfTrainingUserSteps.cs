using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Services;

namespace TPC_UPC.API.Specs.Steps
{
    [Binding]
    public class NotificationUserResultsOfTrainingUserSteps
    {
        private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
        private static Mock<ITrainingTutorRepository> GetDefaultITrainingTutorRepositoryInstance()
        {
            return new Mock<ITrainingTutorRepository>();
        }
        private static Mock<INotificationUserRepository> GetDefaultINotificationUserRepositoryInstance()
        {
            return new Mock<INotificationUserRepository>();
        }

        Training training = new();
        Tutor tutor1 = new();

        TrainingTutor trainingTutor = new();

        Notification notification = new();
        NotificationType notificationtype = new();

        NotificationUser expected1 = new();


        [Given(@"a session of training is created (.*)")]
        public void GivenASessionOfTrainingIsCreated(string p0)
        {
            training.Id = Int32.Parse(p0);
        }

        [When(@"I add a tutor for the training \((.*), (.*)\)")]
        public void WhenIAddATutorForTheTraining(string p0, string p1)
        {
            tutor1.Id = Int32.Parse(p0); tutor1.FirstName = p1;

            trainingTutor.Training = training; trainingTutor.Tutor = tutor1;
        }


        [Then(@"the system send notification for each tutor selected \((.*), (.*)\)")]
        public void ThenTheSystemSendNotificationForEachTutorSelected(string p0, string p1)
        {
            notification.Id = Int32.Parse(p0); 
            notificationtype.Id = 1; notificationtype.Description = p1;
            notification.NotificationType = notificationtype;

            expected1.NotificationId = notification.Id; expected1.Notification = notification;

            expected1.UserId = tutor1.Id; expected1.User = tutor1;

            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockTrainingTutor = GetDefaultITrainingTutorRepositoryInstance();
            var mockNotificationUser = GetDefaultINotificationUserRepositoryInstance();

            TrainingTutorService service = new TrainingTutorService(mockTrainingTutor.Object, mockUnitOfWork.Object, mockNotificationUser.Object);

            TrainingTutorResponse response = service.SaveAsync(trainingTutor).Result;
            Assert.AreEqual(trainingTutor, response.Resource);

            NotificationUserService service2 = new NotificationUserService(mockNotificationUser.Object, mockUnitOfWork.Object);

            mockNotificationUser.Setup(a => a.FindById(expected1.NotificationId, expected1.UserId))
                .Returns(Task.FromResult<NotificationUser>(expected1));

            NotificationUserResponse response2 = service2.GetById(expected1.NotificationId, expected1.UserId).Result;
            Assert.AreEqual(expected1, response2.Resource);
        }
    }
}
