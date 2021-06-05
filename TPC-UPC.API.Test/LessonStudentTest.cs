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
            var mockLessonRepository = GetDefaultILessonRepositoryInstance();
            var mockStudentRepository = GetDefaultIStudentRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();


            //LESSON TYPE
            LessonType lessonType = new LessonType();
            lessonType.Id = 1;
            lessonType.Lessons = new List<Lesson>();
            lessonType.StudentsQuantity = 2;

            //LESSON 
            Lesson lesson = new Lesson();
            lesson.Id = 1;
            lesson.Vacants = 2;
            lesson.LessonType = lessonType;
            lesson.LessonTypeId = lessonType.Id;


            lessonType.Lessons.Add(lesson);

            LessonStudent lessonStudent = new LessonStudent();
            lessonStudent.LessonId = 1;
            lessonStudent.StudentId = 104;


            //STUDENT
            Student student = new Student();
            student.Id = 104;
            lessonStudent.Lesson = lesson;
            lessonStudent.Student = student;



            mockStudentRepository.Setup(r => r.FindById(student.Id))
                .Returns(Task.FromResult<Student>(student));
            mockLessonRepository.Setup(r => r.FindById(lesson.Id))
                .Returns(Task.FromResult<Lesson>(lesson));
            mockLessonStudentRepository.Setup(r => r.FindById(lessonStudent.LessonId, lessonStudent.StudentId))
                .Returns(Task.FromResult<LessonStudent>(lessonStudent));
            mockLessonStudentRepository.Setup(r => r.AddAsync(lessonStudent))
                .Returns(Task.FromResult<LessonStudent>(lessonStudent));

            var service = new LessonStudentService(mockLessonStudentRepository.Object, mockUnitOfWork.Object, mockLessonRepository.Object, mockStudentRepository.Object);
            LessonStudentResponse result = await service.SaveAsync(lessonStudent);
            var message = result.Message;
            message.Should().Be("");

        }


        private Mock<IStudentRepository> GetDefaultIStudentRepositoryInstance()
        {
            return new Mock<IStudentRepository>();
        }

        private Mock<ILessonRepository> GetDefaultILessonRepositoryInstance()
        {
            return new Mock<ILessonRepository>();
        }

        private Mock<IAccountRepository> GetDefaultIAccountRepositoryInstance()
        {
            return new Mock<IAccountRepository>();
        }
        private Mock<ICareerRepository> GetDefaultICareerRepositoryInstance()
        {
            return new Mock<ICareerRepository>();
        }

        private Mock<ITrainingRepository> GetDefaultITrainingRepositoryInstance()
        {
            return new Mock<ITrainingRepository>();
        }

        private Mock<ICoordinatorRepository> GetDefaultICoordinatorRepositoryInstance()
        {
            return new Mock<ICoordinatorRepository>();
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
