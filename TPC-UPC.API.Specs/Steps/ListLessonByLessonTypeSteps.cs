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
    public class ListLessonByLessonTypeSteps
    {
        private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
        private static Mock<ILessonRepository> GetDefaultILessonRepositoryInstance()
        {
            return new Mock<ILessonRepository>();
        }

        //We need ...
        LessonType lessonType1 = new();
        LessonType lessonType2 = new();

        Lesson lesson1 = new();
        Lesson lesson2 = new();
        Lesson lesson3 = new();

        LessonType lessonTypeChoosen = new();

        IEnumerable<Lesson> expectedLessonType1;
        IEnumerable<Lesson> expectedLessonType2;
        List<Lesson> list1 = new List<Lesson>();
        List<Lesson> list2 = new List<Lesson>();

        [Given(@"I want to see detailed information of the lessons by a determinated lesson type")]
        public void GivenIWantToSeeDetailedInformationOfTheLessonsByADeterminatedLessonType()
        {
            lessonType1.Id = 1; lessonType1.LessonTypeName = "Tutoria"; lessonType1.StudentsQuantity = 3;
            lessonType2.Id = 2; lessonType1.LessonTypeName = "Taller"; lessonType1.StudentsQuantity = 30;

            lesson1.Id = 1; lesson1.LessonType = lessonType1;
            lesson2.Id = 2; lesson2.LessonType = lessonType2;
            lesson3.Id = 3; lesson3.LessonType = lessonType1;

            list1.Add(lesson1); list1.Add(lesson3); list2.Add(lesson2);

            expectedLessonType1 = list1;
            expectedLessonType2 = list2;
        }
        
        [When(@"I choose one lessontype \((.*), (.*)\)")]
        public void WhenIChooseOneLessontype(string p0, string p1)
        {
            lessonTypeChoosen.Id = Int32.Parse(p0);
            lessonTypeChoosen.LessonTypeName = p1;
        }
        
        [Then(@"the system returns list of lessons by lessontype (.*)")]
        public void ThenTheSystemReturnsListOfLessonsByLessontype(string p0)
        {
            string response = p0;
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var mockLesson = GetDefaultILessonRepositoryInstance();

            mockLesson.Setup(r => r.ListByLessonTypeIdAsync(1))
             .Returns(Task.FromResult<IEnumerable<Lesson>>(expectedLessonType1));
            mockLesson.Setup(r => r.ListByLessonTypeIdAsync(2))
             .Returns(Task.FromResult<IEnumerable<Lesson>>(expectedLessonType2));

            LessonService service = new LessonService(mockLesson.Object, mockUnitOfWork.Object);

            IEnumerable<Lesson> real = service.ListByLessonTypeIdAsync(lessonTypeChoosen.Id).Result;

            if (lessonTypeChoosen.Id == 1)
            {
                Assert.AreEqual(expectedLessonType1, real);
            }
            else if (lessonTypeChoosen.Id == 2)
            {
                Assert.AreEqual(expectedLessonType2, real);
            }
            else
                response = "False";

            Assert.AreEqual(response, p0);
        }
    }
}
