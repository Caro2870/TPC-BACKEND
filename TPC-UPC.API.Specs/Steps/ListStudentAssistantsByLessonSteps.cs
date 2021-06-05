using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Services;

namespace TPC_UPC.API.Specs.Steps
{
    [Binding]
    public class ListStudentAssistantsByLessonSteps
    {
        private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
        private static Mock<ILessonRepository> GetDefaultILessonRepositoryInstance()
        {
            return new Mock<ILessonRepository>();
        }
        private static Mock<IStudentRepository> GetDefaultIStudentRepositoryInstance()
        {
            return new Mock<IStudentRepository>();
        }
        private static Mock<ILessonStudentRepository> GetDefaultILessonStudentInstance()
        {
            return new Mock<ILessonStudentRepository>();
        }

        Student student1 = new();
        Student student2 = new();
        Student student3 = new();

        Lesson lessonChoosen = new();
        LessonStudent lessonStudent1 = new();
        LessonStudent lessonStudent2 = new();
        LessonStudent lessonStudent3 = new();

        IEnumerable<LessonStudent> expected;
        List<LessonStudent> list = new List<LessonStudent>();

        [Given(@"I am a tutor and want to see the list of students who enter to the lesson")]
        public void GivenIAmATutorAndWantToSeeTheListOfStudentsWhoEnterToTheLesson()
        {
            //Creating Students
            student1.Id = 1; student1.FirstName = "Paula";
            student2.Id = 2; student2.FirstName = "Daniel";
            student3.Id = 3; student3.FirstName = "Karina";
        }
        
        [When(@"I choose one lesson (.*)")]
        public void WhenIChooseOneLesson(string p0)
        {
            //Creating Lesson
            lessonChoosen.Id = Int32.Parse(p0); lessonChoosen.Vacants = 10;
            //Creating LessonStudent
            lessonStudent1.Lesson = lessonChoosen; lessonStudent1.Student = student1; lessonStudent1.StudentId = student1.Id; lessonStudent1.LessonId = lessonChoosen.Id;
            lessonStudent2.Lesson = lessonChoosen; lessonStudent2.Student = student2; lessonStudent2.StudentId = student2.Id; lessonStudent2.LessonId = lessonChoosen.Id;
            lessonStudent3.Lesson = lessonChoosen; lessonStudent3.Student = student3; lessonStudent3.StudentId = student3.Id; lessonStudent3.LessonId = lessonChoosen.Id;

            lessonStudent1.Assistance = true;
            lessonStudent2.Assistance = true;
            lessonStudent3.Assistance = false;

            list.Add(lessonStudent1);
            list.Add(lessonStudent2);

            expected = list;
        }
        
        [Then(@"the system shows the list")]
        public void ThenTheSystemShowsTheList()
        {
            string response = "True";
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockLesson = GetDefaultILessonRepositoryInstance();
            var mockLessonStudent = GetDefaultILessonStudentInstance();
            var mockStudent = GetDefaultIStudentRepositoryInstance();

            mockLessonStudent.Setup(r => r.ListStudentAssistantsByLessonIdAsync(lessonChoosen.Id))
                .Returns(Task.FromResult<IEnumerable<LessonStudent>>(expected));

            LessonStudentService service = new LessonStudentService(mockLessonStudent.Object, mockUnitOfWork.Object, mockLesson.Object, mockStudent.Object);

            IEnumerable<LessonStudent> real = service.ListStudentAssistantsByLessonIdAsync(lessonChoosen.Id).Result;

            Assert.AreEqual(expected, real);
        }
    }
}
