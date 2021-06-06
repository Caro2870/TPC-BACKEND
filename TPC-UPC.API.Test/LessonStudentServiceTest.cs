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
    class LessonStudentServiceTest
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

        [Test]
        public async Task AsyncWhenCreateALessonStudentGivenAnStudentThatIsAlreadyThere()
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
            mockLessonStudentRepository.Setup(r => r.ExistsByLessonIdAndStudentId(lessonStudent.LessonId, lessonStudent.StudentId))
                .Returns(Task.FromResult<LessonStudent>(lessonStudent));
            var service = new LessonStudentService(mockLessonStudentRepository.Object, mockUnitOfWork.Object, mockLessonRepository.Object, mockStudentRepository.Object);
            LessonStudentResponse result = await service.SaveAsync(lessonStudent);
            var message = result.Message;
            message.Should().Be("You are already part of this lesson");
        }
        [Test]
        public async Task AsyncWhenCreateALessonStudentWhenLessonIsFull()
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
            lesson.Contador = 2;

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
            mockLessonStudentRepository.Setup(r => r.ExistsByLessonIdAndStudentId(lessonStudent.LessonId, lessonStudent.StudentId))
                .Returns(Task.FromResult<LessonStudent>(lessonStudent));
            var service = new LessonStudentService(mockLessonStudentRepository.Object, mockUnitOfWork.Object, mockLessonRepository.Object, mockStudentRepository.Object);
            LessonStudentResponse result = await service.SaveAsync(lessonStudent);
            var message = result.Message;
            message.Should().Be("This lesson is full");
        }

        [Test]
        public async Task AsyncWhenCreateALessonStudentWhenLessonIsNotFound()
        {
            var mockLessonStudentRepository = GetDefaultILessonStudentRepositoryInstance();
            var mockLessonRepository = GetDefaultILessonRepositoryInstance();
            var mockStudentRepository = GetDefaultIStudentRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();


                LessonStudent lessonStudent = new LessonStudent();
                lessonStudent.StudentId = 104;
            
            
                //STUDENT
                Student student = new Student();
            student.Id = 104;
                lessonStudent.Student = student;
                mockStudentRepository.Setup(r => r.FindById(student.Id))
                    .Returns(Task.FromResult<Student>(student));
            mockLessonStudentRepository.Setup(r => r.FindById(lessonStudent.LessonId, lessonStudent.StudentId))
                    .Returns(Task.FromResult<LessonStudent>(lessonStudent));
            mockLessonStudentRepository.Setup(r => r.AddAsync(lessonStudent))
                    .Returns(Task.FromResult<LessonStudent>(lessonStudent));

            var service = new LessonStudentService(mockLessonStudentRepository.Object, mockUnitOfWork.Object, mockLessonRepository.Object, mockStudentRepository.Object);
            LessonStudentResponse result = await service.SaveAsync(lessonStudent);
            var message = result.Message;
            message.Should().Be("Lesson not found");
        }

        [Test]
        public async Task AsyncWhenCreateALessonStudentWhenStudentIsNotFound()
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


            mockLessonRepository.Setup(r => r.FindById(lesson.Id))
                .Returns(Task.FromResult<Lesson>(lesson));
            mockLessonStudentRepository.Setup(r => r.FindById(lessonStudent.LessonId, lessonStudent.StudentId))
                .Returns(Task.FromResult<LessonStudent>(lessonStudent));
            mockLessonStudentRepository.Setup(r => r.AddAsync(lessonStudent))
                .Returns(Task.FromResult<LessonStudent>(lessonStudent));

            var service = new LessonStudentService(mockLessonStudentRepository.Object, mockUnitOfWork.Object, mockLessonRepository.Object, mockStudentRepository.Object);
            LessonStudentResponse result = await service.SaveAsync(lessonStudent);
            var message = result.Message;
            message.Should().Be("Student not found");

        }

        private Mock<ILessonStudentRepository> GetDefaultILessonStudentRepositoryInstance()
        {
            return new Mock<ILessonStudentRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

        private Mock<IStudentRepository> GetDefaultIStudentRepositoryInstance()
        {
            return new Mock<IStudentRepository>();
        }

        private Mock<ILessonRepository> GetDefaultILessonRepositoryInstance()
        {
            return new Mock<ILessonRepository>();
        }
    }
}
