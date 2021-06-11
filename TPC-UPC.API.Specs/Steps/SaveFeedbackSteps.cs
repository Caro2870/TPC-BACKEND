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
    public class SaveFeedbackSteps
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

        public SaveFeedbackSteps(ScenarioContext scenarioContext)
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

        //Escenario 1 y 2
        [Given(@"that the lesson has ended and the student must give a grade for that lesson\((.*), (.*)\)")]
        public void GivenThatTheLessonHasEndedAndTheStudentMustGiveAGradeForThatLesson(string p0, string p1)
        {
            //Student
            int studentId = Int32.Parse(p1);
            _student.Id = studentId;

            //LessonType
            _lessonType.Id = 1;

            //Lesson
            int lessonId = Int32.Parse(p0);
            _lesson.Id = lessonId;
            _lesson.LessonType = _lessonType;
            _lesson.LessonTypeId = _lessonType.Id;

            _lessonStudent.StudentId = _student.Id;
            _lessonStudent.Student = _student;
            _lessonStudent.LessonId = _lesson.Id;
            _lessonStudent.Lesson = _lesson;

            _lessonStudentRepository.Setup(r => r.FindById(lessonId, studentId))
               .Returns(Task.FromResult<LessonStudent>(_lessonStudent));
        }
        
        [When(@"the student sends unmarked number of stars\((.*), (.*), (.*), (.*), (.*)\)")]
        public void WhenTheStudentSendsUnmarkedNumberOfStars(string p0, string p1, string p2, string p3, string p4)
        {
            int sameLessonId = Int32.Parse(p0);
            int sameStudentId = Int32.Parse(p1);
            int qualification = Int32.Parse(p2);
            bool complaint = bool.Parse(p4);

            LessonStudent newLessonStudent = new()
            {
                Qualification = qualification,
                Comment = p3,
                Complaint = complaint
            };

            _response = _lessonStudentService.SaveFeedbackAsync(sameLessonId, sameStudentId, newLessonStudent);
        }

        [When(@"the student sends the number of stars\((.*), (.*), (.*), (.*), (.*)\)")]
        public void WhenTheStudentSendsTheNumberOfStars(string p0, string p1, string p2, string p3, string p4)
        {
            int sameLessonId = Int32.Parse(p0);
            int sameStudentId = Int32.Parse(p1);
            int qualification = Int32.Parse(p2);
            bool complaint = bool.Parse(p4);

            LessonStudent newLessonStudent = new()
            {
                Qualification = qualification,
                Comment = p3,
                Complaint = complaint
            };

            _response = _lessonStudentService.SaveFeedbackAsync(sameLessonId, sameStudentId, newLessonStudent);

            Assert.AreEqual(newLessonStudent.Qualification, _response.Result.Resource.Qualification);
        }

        //Escenario 3
        [Given(@"that the student wants to send a comment about the lesson attended\((.*), (.*)\)")]
        public void GivenThatTheStudentWantsToSendACommentAboutTheLessonAttended(string p0, string p1)
        {
            //Student
            int studentId = Int32.Parse(p1);
            _student.Id = studentId;

            //LessonType
            _lessonType.Id = 1;

            //Lesson
            int lessonId = Int32.Parse(p0);
            _lesson.Id = lessonId;
            _lesson.LessonType = _lessonType;
            _lesson.LessonTypeId = _lessonType.Id;

            _lessonStudent.StudentId = _student.Id;
            _lessonStudent.Student = _student;
            _lessonStudent.LessonId = _lesson.Id;
            _lessonStudent.Lesson = _lesson;

            _lessonStudentRepository.Setup(r => r.FindById(lessonId, studentId))
               .Returns(Task.FromResult<LessonStudent>(_lessonStudent));
        }

        [When(@"fills in the information he wants to leave as a comment\((.*), (.*), (.*), (.*), (.*)\)")]
        public void WhenFillsInTheInformationHeWantsToLeaveAsAComment(string p0, string p1, string p2, string p3, string p4)
        {
            int sameLessonId = Int32.Parse(p0);
            int sameStudentId = Int32.Parse(p1);
            int qualification = Int32.Parse(p2);
            bool complaint = bool.Parse(p4);

            LessonStudent newLessonStudent = new()
            {
                Qualification = qualification,
                Comment = p3,
                Complaint = complaint
            };

            _response = _lessonStudentService.SaveFeedbackAsync(sameLessonId, sameStudentId, newLessonStudent);

            Assert.AreEqual(newLessonStudent.Qualification, _response.Result.Resource.Qualification);
        }

        //Escenario 4
        [Given(@"that the student wants to send a complaint about the lesson attended\((.*), (.*)\)")]
        public void GivenThatTheStudentWantsToSendAComplaintAboutTheLessonAttended(string p0, string p1)
        {
            //Student
            int studentId = Int32.Parse(p1);
            _student.Id = studentId;

            //LessonType
            _lessonType.Id = 1;

            //Lesson
            int lessonId = Int32.Parse(p0);
            _lesson.Id = lessonId;
            _lesson.LessonType = _lessonType;
            _lesson.LessonTypeId = _lessonType.Id;

            _lessonStudent.StudentId = _student.Id;
            _lessonStudent.Student = _student;
            _lessonStudent.LessonId = _lesson.Id;
            _lessonStudent.Lesson = _lesson;

            _lessonStudentRepository.Setup(r => r.FindById(lessonId, studentId))
               .Returns(Task.FromResult<LessonStudent>(_lessonStudent));
        }
        
        [When(@"fills in the information he wants to leave as a complaint and identifies it as a complaint\((.*), (.*), (.*), (.*), (.*)\)")]
        public void WhenFillsInTheInformationHeWantsToLeaveAsAComplaintAndIdentifiesItAsAComplaint(string p0, string p1, string p2, string p3, string p4)
        {
            int sameLessonId = Int32.Parse(p0);
            int sameStudentId = Int32.Parse(p1);
            int qualification = Int32.Parse(p2);
            bool complaint = bool.Parse(p4);

            LessonStudent newLessonStudent = new()
            {
                Qualification = qualification,
                Comment = p3,
                Complaint = complaint
            };

            _response = _lessonStudentService.SaveFeedbackAsync(sameLessonId, sameStudentId, newLessonStudent);

            Assert.AreEqual(newLessonStudent.Qualification, _response.Result.Resource.Qualification);
        }
        
        //
        [Then(@"the message that returns should be(.*)")]
        public void ThenTheMessageThatReturnsShouldBe(string actualResponse)
        {
            string a = _response.Result.Message;
            Assert.AreEqual(a, actualResponse);
        }
        
        [Then(@"the system should return(.*)")]
        public void ThenTheSystemShouldReturn(string actualResponse)
        {
            string a = _response.Result.Success.ToString();
            Assert.AreEqual(a, actualResponse);
        }
    }
}
