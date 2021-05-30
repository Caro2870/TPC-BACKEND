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
    class LessonStudentTest
    {
        [SetUp]
        public void Setup()
        {
        }
           
        [Test]
        public async Task SaveAsyncWhenLessonStudentReturnsSuccess()
        {
            var mockLessonStudentRepository = GetDefaultILessonStudentRepositoryInstance();
            var mockUnityOfWork = GetDefaultIUnitOfWorkInstance();
            LessonStudent lessonStudent = new LessonStudent();
            mockLessonStudentRepository.Setup(r => r.AddAsync(lessonStudent))
                .Returns(Task.FromResult(lessonStudent));
            var service = new LessonStudentService(mockLessonStudentRepository.Object, mockUnityOfWork.Object);
            LessonStudentResponse result = await service.SaveAsync(lessonStudent);
            var message = result.Message;
            message.Should().Be("");
        }

        [Test]
        public async Task GetAsyncAllLessonsByStudentId()
        {
            var mockLessonStudentRepository = GetDefaultILessonStudentRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            LessonStudent lessonStudent = new LessonStudent();
            mockLessonStudentRepository.Setup(r => r.AddAsync(lessonStudent))
                .Returns(Task.FromResult<LessonStudent>(lessonStudent));
            int studentId = 1;
            lessonStudent.LessonId = 1;
            lessonStudent.StudentId = 1;
            lessonStudent.Topic = "mate";
            var service = new LessonStudentService(mockLessonStudentRepository.Object, mockIUnitOfWork.Object);
            var message = service.ListByStudentIdAsync(studentId);

            message.Should().Be("");
        }

        private Mock<ILessonStudentRepository> GetDefaultILessonStudentRepositoryInstance()
        {
            return new Mock<ILessonStudentRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
