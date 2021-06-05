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
    public class AverageScoreDisplayedSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IEnumerable<Lesson> iLessons;
        private IEnumerable<LessonStudent> iLessonStudents;
        private double average;
        private double message;

        public AverageScoreDisplayedSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
        private static Mock<ILessonRepository> GetDefaultILessonRepositoryInstance()
        {
            return new Mock<ILessonRepository>();
        }
        private static Mock<ITutorRepository> GetDefaultITutorRepositoryInstance()
        {
            return new Mock<ITutorRepository>();
        }
        private static Mock<IFacultyRepository> GetDefaultIFacultyRepositoryInstance()
        {
            return new Mock<IFacultyRepository>();
        }
        private static Mock<IAccountRepository> GetDefaultIAccountRepositoryInstance()
        {
            return new Mock<IAccountRepository>();
        }
        private static Mock<ILessonStudentRepository> GetDefaultILessonStudentRepositoryInstance()
        {
            return new Mock<ILessonStudentRepository>();
        }
        private static Mock<ILessonRepository> _lessonRepository;
        private static Mock<ILessonStudentRepository> _lessonStudentRepository;
        private TutorService _tutorService;

        [Given(@"the tutor (.*) wants to see the average score for a course (.*) and type of course (.*)")]
        public void GivenTheTutorWantsToSeeTheAverageScoreForACourseAndTypeOfCourse(int p0, int p1, int p2)
        {
            _lessonRepository = GetDefaultILessonRepositoryInstance();

            List<Lesson> lessons = new List<Lesson>();
            Lesson lesson = new Lesson();
            lesson.Id = 1;
            //Lesson lesson1 = new Lesson();
            //lesson1.Id = 2;
            //Lesson lesson2 = new Lesson();
            //lesson2.Id = 3;
            lessons.Add(lesson);
            //lessons.Add(lesson1);
            //lessons.Add(lesson2);
            iLessons = lessons as IEnumerable<Lesson>;
            _lessonRepository.Setup(r => r.ListByTutorIdAndCourseIdAndLessonTypeIdAsync(p0, p1, p2)).
                Returns(Task.FromResult<IEnumerable<Lesson>>(iLessons));

            List<LessonStudent> lessonStudents = new List<LessonStudent>();
            LessonStudent lessonStudent = new LessonStudent();
            lessonStudent.LessonId = lesson.Id;
            lessonStudent.Qualification = 3;
            LessonStudent lessonStudent1 = new LessonStudent();
            lessonStudent.LessonId = lesson.Id;
            lessonStudent1.Qualification = 5;

            lessonStudents.Add(lessonStudent);
            lessonStudents.Add(lessonStudent1);

            iLessonStudents = lessonStudents as IEnumerable<LessonStudent>;

            _lessonStudentRepository = GetDefaultILessonStudentRepositoryInstance();
            _lessonStudentRepository.Setup(r=> r.ListStudentsByLessonIdAsync(lesson.Id))
                .Returns(Task.FromResult<IEnumerable<LessonStudent>>(iLessonStudents));

        }

        [When(@"the tutor makes the petition")]
        public void WhenTheTutorMakesThePetition()
        {
            _tutorService = new TutorService(GetDefaultITutorRepositoryInstance().Object, GetDefaultIFacultyRepositoryInstance().Object,
                GetDefaultIAccountRepositoryInstance().Object, GetDefaultIUnitOfWorkInstance().Object, _lessonRepository.Object, _lessonStudentRepository.Object);
            average = _tutorService.GetWorkshopsAverage(1,1,1);
        }
        
        [Then(@"the system returns the average score given to him of the whole cycle  (.*)")]
        public void ThenTheSystemReturnsTheAverageScoreGivenToHimOfTheWholeCycle(int p0)
        {
            Assert.AreEqual(average, p0);
        }

        //2ND SCENARIO

        [Given(@"there are not lessons for the specified parameters for tutor (.*) course (.*) and type of course (.*)")]
        public void GivenThereAreNotLessonsForTheSpecifiedParametersForTutorCourseAndTypeOfCourse(int p0, int p1, int p2)
        {
            List<Lesson> lessons = new List<Lesson>();
            iLessons = lessons as IEnumerable<Lesson>;
            _lessonRepository.Setup(r => r.ListByTutorIdAndCourseIdAndLessonTypeIdAsync(p0,p1, p2)).
                    Returns(Task.FromResult<IEnumerable<Lesson>>(iLessons));
        }

        [When(@"the tutor asks for the data")]
        public void WhenTheTutorAsksForTheData()
        {
            _tutorService = new TutorService(GetDefaultITutorRepositoryInstance().Object, GetDefaultIFacultyRepositoryInstance().Object,
                           GetDefaultIAccountRepositoryInstance().Object, GetDefaultIUnitOfWorkInstance().Object, _lessonRepository.Object, _lessonStudentRepository.Object);
            message = _tutorService.GetWorkshopsAverage(1, 1, 1);
        }


        [Then(@"the system returns the following message (.*)")]
        public void ThenTheSystemReturnsTheFollowingMessage(int p0)
        {
            Assert.AreEqual(message, p0);
        }

    }
}
