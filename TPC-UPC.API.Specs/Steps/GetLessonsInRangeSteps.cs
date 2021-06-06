using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Services;
using System.Linq;
using NUnit.Framework;

namespace TPC_UPC.API.Specs.Steps
{
    [Binding]
    public class GetLessonsInRangeSteps
    {
        private readonly ScenarioContext _scenarioContext;
        int items;
        string message;
        private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

        private static Mock<ILessonRepository> GetDefaultILessonRepositoryInstance()
        {
            return new Mock<ILessonRepository>();
        }

        private LessonService _lessonService;
        private static Mock<ILessonRepository> _lessonRepository;
        private IEnumerable<Lesson> iLessons;
        public GetLessonsInRangeSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the tutor wants to list lessons according to a range of dates \((.*), (.*), (.*), (.*), (.*), (.*)\)")]
        public void GivenTheTutorWantsToListLessonsAccordingToARangeOfDates(string p0, string p1, string p2, string p3, string p4, string p5)
        {
            _lessonRepository = GetDefaultILessonRepositoryInstance();
            Lesson lesson = new Lesson();
            Lesson lesson1 = new Lesson();
            Lesson lesson2 = new Lesson();

            List<Lesson> lessons = new List<Lesson>();
            lessons.Add(lesson);
            lessons.Add(lesson1);
            lessons.Add(lesson2);
            iLessons = lessons as IEnumerable<Lesson>;

        }

        [When(@"the tutor enters the parans \((.*), (.*)\)")]
        public void WhenTheTutorEntersTheParans(string p0, string p1)
        {

            DateTime start = Convert.ToDateTime(p0);
            DateTime end = Convert.ToDateTime(p1);

            _lessonRepository.Setup(r => r.ListByRangeOfDates(start, end)).
                Returns(Task.FromResult<IEnumerable<Lesson>>(iLessons));

            _lessonService = new LessonService(_lessonRepository.Object, GetDefaultIUnitOfWorkInstance().Object);
            items = _lessonService.ListByRangeOfDates(start, end).Result.Count();

        }

        [Then(@"the result for this scenario should be the number of lessons in this range (.*)")]
        public void ThenTheResultForThisScenarioShouldBeTheNumberOfLessonsInThisRange(int p1)
        {
            Assert.AreEqual(items, p1);
        }

        //2ND SCENARIO

        [When(@"any lesson is returned \((.*), (.*)\)")]
        public void WhenAnyLessonIsReturned(string p0, string p1)
        {
            List<Lesson> lessons = new List<Lesson>();
            iLessons = lessons as IEnumerable<Lesson>;
            DateTime start = Convert.ToDateTime(p0);
            DateTime end = Convert.ToDateTime(p1);
            _lessonRepository.Setup(r => r.ListByRangeOfDates(start, end)).
                Returns(Task.FromResult<IEnumerable<Lesson>>(iLessons));
            _lessonService = new LessonService(_lessonRepository.Object, GetDefaultIUnitOfWorkInstance().Object);
            message = _lessonService.ListByRangeOfDates(start, end).Exception.Message;
        }



        [Then(@"the message that returns for this scenario should be (.*)")]
        public void ThenTheMessageThatReturnsForThisScenarioShouldBe(string p0)
        {
            Assert.AreEqual(p0, message);

        }

    }
}
