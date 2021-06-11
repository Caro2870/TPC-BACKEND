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
    public class CancelLessonReservationSteps
    {
        public readonly ScenarioContext _scenarioContext;
        private Lesson _lesson = new();
        private Student _student = new();
        private LessonStudent _lessonStudent = new();
        private LessonType _lessonType = new();
        private Task<LessonStudentResponse> _response;

        private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

        private static Mock<IStudentRepository> _studentRepository = new Mock<IStudentRepository>();

        private static Mock<ILessonRepository> _lessonRepository = new Mock<ILessonRepository>();

        public CancelLessonReservationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        private static Mock<ILessonStudentRepository> _lessonStudentRepository = new Mock<ILessonStudentRepository>();

        private LessonStudentService _lessonStudentService = new LessonStudentService(
            _lessonStudentRepository.Object,
            GetDefaultIUnitOfWorkInstance().Object,
            _lessonRepository.Object,
            _studentRepository.Object
            );

        //Escenarios "First step"
        [Given(@"a student exist\((.*)\)")]
        public void GivenAStudentExist(string p0)
        {
            int studentId = Int32.Parse(p0);
            _student.Id = studentId;

            _studentRepository.Setup(r => r.FindById(_student.Id))
               .Returns(Task.FromResult<Student>(_student));
        }


        //Escenarios "Second step"
        //Escenario 1
        [Given(@"a workshop lesson exist\((.*)\)")]
        public void GivenAWorkshopLessonExist(string p0)
        {
            //LessonType
            _lessonType.Id = 1;

            //Lesson
            int lessonId = Int32.Parse(p0);
            _lesson.Id = lessonId;
            _lesson.StartDate = DateTime.Parse("7/31/2021 12:00:00");
            _lesson.LessonType = _lessonType;
            _lesson.LessonTypeId = _lessonType.Id;

            _lessonType.Lessons.Add(_lesson);

            _lessonRepository.Setup(r => r.FindById(_lesson.Id))
               .Returns(Task.FromResult<Lesson>(_lesson));
        }

        //Escenario 2
        [Given(@"a tutoring lesson exist\((.*)\)")]
        public void GivenATutoringLessonExist(string p0)
        {
            //LessonType
            _lessonType.Id = 1;

            //Lesson
            int lessonId = Int32.Parse(p0);
            _lesson.Id = lessonId;
            _lesson.StartDate = DateTime.Parse("7/31/2021 12:00:00");
            _lesson.LessonType = _lessonType;
            _lesson.LessonTypeId = _lessonType.Id;

            _lessonType.Lessons.Add(_lesson);

            _lessonRepository.Setup(r => r.FindById(_lesson.Id))
               .Returns(Task.FromResult<Lesson>(_lesson));
        }

        //Escenario 3
        [Given(@"a lesson exist\((.*)\)")]
        public void GivenALessonExist(string p0)
        {
            //LessonType
            _lessonType.Id = 1;

            //Lesson
            int lessonId = Int32.Parse(p0);
            _lesson.Id = lessonId;
            _lesson.StartDate = DateTime.Parse("6/10/2021 21:15:00");
            _lesson.LessonType = _lessonType;
            _lesson.LessonTypeId = _lessonType.Id;

            _lessonType.Lessons.Add(_lesson);

            _lessonRepository.Setup(r => r.FindById(_lesson.Id))
               .Returns(Task.FromResult<Lesson>(_lesson));
        }


        //Escenarios "Third step"
        [Given(@"that the student have a reservation")]
        public void GivenThatTheStudentHaveAReservation()
        {
            _lessonStudent.StudentId = _student.Id;
            _lessonStudent.Student = _student;
            _lessonStudent.LessonId = _lesson.Id;
            _lessonStudent.Lesson = _lesson;

            _lessonStudentRepository.Setup(r => r.FindById(_lessonStudent.LessonId, _lessonStudent.StudentId))
               .Returns(Task.FromResult<LessonStudent>(_lessonStudent));
        }


        //Escenarios "Fourth and final step"
        //Escenarios 1 y 2
        [When(@"the student cancels the reservation before the allowed cancellation time\((.*), (.*)\)")]
        public void WhenTheStudentCancelsTheReservationBeforeTheAllowedCancellationTime(string p0, string p1)
        {
            int sameLessonId = Int32.Parse(p0);
            int sameStudentId = Int32.Parse(p1);

            _response = _lessonStudentService.DeleteAsync(sameLessonId, sameStudentId);

            Assert.AreEqual(_lessonStudent, _response.Result.Resource);
        }

        [Then(@"the system deletes the reservation(.*)")]
        public void ThenTheSystemDeletesTheReservation(string actualResponse)
        {
            string a = _response.Result.Success.ToString();
            Assert.AreEqual(a, actualResponse);
        }

        //Escenario 3
        [When(@"the student tries to cancel his reservation after the allowed cancellation time\((.*), (.*)\)")]
        public void WhenTheStudentTriesToCancelHisReservationAfterTheAllowedCancellationTime(string p0, string p1)
        {
            int sameLessonId = Int32.Parse(p0);
            int sameStudentId = Int32.Parse(p1);

            _response = _lessonStudentService.DeleteAsync(sameLessonId, sameStudentId);
        }

        [Then(@"the student displays an error message indicating that the cancellation was not completed due to time constraints(.*)")]
        public void ThenTheStudentDisplaysAnErrorMessageIndicatingThatTheCancellationWasNotCompletedDueToTimeConstraints(string actualResponse)
        {
            string a = _response.Result.Message;
            Assert.AreEqual(a, actualResponse);
        }

        


    }
}
