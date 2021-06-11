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

        private static Mock<IStudentRepository> GetDefaultIStudentRepositoryInstance()
        {
            return new Mock<IStudentRepository>();
        }

        private static Mock<ILessonRepository> GetDefaultILessonRepositoryInstance()
        {
            return new Mock<ILessonRepository>();
        }

        public CancelLessonReservationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        private static Mock<ILessonStudentRepository> _lessonStudentRepository = new Mock<ILessonStudentRepository>();

        private LessonStudentService _lessonStudentService = new LessonStudentService(
            _lessonStudentRepository.Object,
            GetDefaultIUnitOfWorkInstance().Object,
            GetDefaultILessonRepositoryInstance().Object,
            GetDefaultIStudentRepositoryInstance().Object
            );

        //Escenario 1, 2 y 3
        [Given(@"that the student wants to cancel reservation\((.*), (.*)\)")]
        public void GivenThatTheStudentWantsToCancelReservation(string p0, string p1)
        {
            //Student
            int studentId = Int32.Parse(p1);
            _student.Id = studentId;

            //LessonType
            _lessonType.Id = 1;

            //Lesson
            int lessonId = Int32.Parse(p0);
            _lesson.Id = lessonId;
            _lesson.StartDate = DateTime.Parse("7/31/2021 12:00:00");
            _lesson.LessonType = _lessonType;
            _lesson.LessonTypeId = _lessonType.Id;

            _lessonStudent.StudentId = _student.Id;
            _lessonStudent.Student = _student;
            _lessonStudent.LessonId = _lesson.Id;
            _lessonStudent.Lesson = _lesson;

            _lessonStudentRepository.Setup(r => r.FindById(lessonId, studentId))
               .Returns(Task.FromResult<LessonStudent>(_lessonStudent));
        }
        
        [When(@"the student cancels the reservation before the allowed cancellation time\((.*), (.*)\)")]
        public void WhenTheStudentCancelsTheReservationBeforeTheAllowedCancellationTime(string p0, string p1)
        {
            int sameLessonId = Int32.Parse(p0);
            int sameStudentId = Int32.Parse(p1);

            _response = _lessonStudentService.DeleteAsync(sameLessonId, sameStudentId);

            Assert.AreEqual(_lessonStudent, _response.Result.Resource);
        }

        [Given(@"that the student wants to cancel reservation late\((.*), (.*)\)")]
        public void GivenThatTheStudentWantsToCancelReservationLate(string p0, string p1)
        {
            //Student
            int studentId = Int32.Parse(p1);
            _student.Id = studentId;

            //LessonType
            _lessonType.Id = 1;

            //Lesson
            int lessonId = Int32.Parse(p0);
            _lesson.Id = lessonId;
            _lesson.StartDate = DateTime.Parse("6/10/2021 21:15:00");
            _lesson.LessonType = _lessonType;
            _lesson.LessonTypeId = _lessonType.Id;

            _lessonStudent.StudentId = _student.Id;
            _lessonStudent.Student = _student;
            _lessonStudent.LessonId = _lesson.Id;
            _lessonStudent.Lesson = _lesson;

            _lessonStudentRepository.Setup(r => r.FindById(lessonId, studentId))
               .Returns(Task.FromResult<LessonStudent>(_lessonStudent));
        }

        [When(@"the student tries to cancel his reservation after the allowed cancellation time\((.*), (.*)\)")]
        public void WhenTheStudentTriesToCancelHisReservationAfterTheAllowedCancellationTime(string p0, string p1)
        {
            int sameLessonId = Int32.Parse(p0);
            int sameStudentId = Int32.Parse(p1);

            _response = _lessonStudentService.DeleteAsync(sameLessonId, sameStudentId);
        }
        
        [Then(@"the system deletes the reservation(.*)")]
        public void ThenTheSystemDeletesTheReservation(string actualResponse)
        {
            string a = _response.Result.Success.ToString();
            Assert.AreEqual(a, actualResponse);
        }
        
        [Then(@"the student displays an error message indicating that the cancellation was not completed due to time constraints(.*)")]
        public void ThenTheStudentDisplaysAnErrorMessageIndicatingThatTheCancellationWasNotCompletedDueToTimeConstraints(string actualResponse)
        {
            string a = _response.Result.Message;
            Assert.AreEqual(a, actualResponse);
        }
    }
}
