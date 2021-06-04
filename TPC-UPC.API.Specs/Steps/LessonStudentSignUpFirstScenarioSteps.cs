using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Services;

namespace TPC_UPC.API.Specs.Steps
{
    [Binding]
    public sealed class LessonStudentSignUpFirstScenarioSteps
    {
        public readonly ScenarioContext _scenarioContext;
        private Lesson _lesson;
        private Student _student;
        private LessonStudent _lessonStudent;
        private Task<LessonStudentResponse> _response;

        public LessonStudentSignUpFirstScenarioSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _lesson = new Lesson();
            _student = new Student();
            _lessonStudent = new LessonStudent();
        }

        private static Mock<ICareerRepository> GetDefaultICareerRepositoryInstance()
        {
            return new Mock<ICareerRepository>();
        }

        private static Mock<IAccountRepository> GetDefaultIAccountRepositoryInstance()
        {
            return new Mock<IAccountRepository>();
        }

        private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
        private static Mock<IStudentRepository> _studentRepository = new Mock<IStudentRepository>();

        private static Mock<ILessonRepository> _lessonRepository = new Mock<ILessonRepository>();

        private static Mock<ILessonStudentRepository> _lessonStudentRepository = new Mock<ILessonStudentRepository>();

        private ILessonService _lessonService = new LessonService(_lessonRepository.Object, GetDefaultIUnitOfWorkInstance().Object);

        private IStudentService _studentService = new StudentService(_studentRepository.Object, GetDefaultIAccountRepositoryInstance().Object,
            GetDefaultICareerRepositoryInstance().Object, GetDefaultIUnitOfWorkInstance().Object);

        private ILessonStudentService _lessonStudentService = new LessonStudentService(_lessonStudentRepository.Object, GetDefaultIUnitOfWorkInstance().Object,
           _lessonRepository.Object, _studentRepository.Object);

        [Given(@"the Student is created \((.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)\)")]
        public void GivenTheStudentIsCreated(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7)
        {
            int id = Int32.Parse(p0);
            Debugger.Launch();
            _student.Id = id;
            Debugger.Launch();
            _student.FirstName = p1;
            _student.LastName = p2;
            _student.Mail = p3;
            _student.PhoneNumber = p4;
            _student.AccountId = Int32.Parse(p5);
            _student.CareerId = Int32.Parse(p6);
            _student.CycleNumber = Int32.Parse(p7);
            Debugger.Launch();

            _studentRepository.Setup(r => r.AddAsync(_student))
               .Returns(Task.FromResult<Student>(_student));
            Debugger.Launch();

        }

        [Given(@"the lesson is created \((.*), (.*), (.*), (.*), (.*), (.*)\)")]
        public void GivenTheLessonIsCreated(string p0, string p1, string p2, string p3, string p4, string p5)
        {
            _lesson.Id = Int32.Parse(p0);
            _lesson.ScheduleId = Int32.Parse(p1);
            _lesson.Description = p2;
            _lesson.TutorId = Int32.Parse(p3);
            _lesson.LessonTypeId = Int32.Parse(p4);
            _lesson.CourseId = Int32.Parse(p5);

            _lessonRepository.Setup(r => r.AddAsync(_lesson))
                .Returns(Task.FromResult<Lesson>(_lesson));
        }
        
        [When(@"the student signs up for the first time for this lesson (.*)")]
        public void WhenTheStudentSignsUpForTheFirstTimeForThisLesson(string p0)
        {
            //_lessonStudentRepository.Setup(r => r.FindById(_lesson.Id, _student.Id))
            //    .Returns(Task.FromResult<LessonStudent>(_lessonStudent));

            _lessonStudent.StudentId = _student.Id;
            _lessonStudent.Student = _student;
            _lessonStudent.LessonId = _lesson.Id;
            _lessonStudent.Lesson = _lesson;

            _response = _lessonStudentService.SaveAsync(_lessonStudent);
        }

        [Then(@"what returns should be (.*)")]
        public void ThenWhatReturnsShouldBe(string p0)
        {
            //    //_lessonStudentRepository.Setup(r => r.AddAsync(_lessonStudent)).Returns(Task.FromResult(_lessonStudent));
            //    string a = _response.Result.Success.ToString();
            Assert.AreEqual(_response.Result.Success.ToString(), p0);
        }
    }
}