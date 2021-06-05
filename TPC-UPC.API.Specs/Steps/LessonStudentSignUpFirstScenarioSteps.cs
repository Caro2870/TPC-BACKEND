using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
        private LessonType lessonType;

        private LessonStudentResponse _response;
        private LessonStudentResponse _secondResponse;
        private LessonStudentResponse _thirdResponse;



        private static Mock<IStudentRepository> _studentRepository;

        private static Mock<ILessonRepository> _lessonRepository;

        private static Mock<ILessonStudentRepository> _lessonStudentRepository;


        private LessonStudentService _lessonStudentService;


        public LessonStudentSignUpFirstScenarioSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

        //1ST SCENARIO
        [Given(@"the Student is created \((.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*)\)")]
        public void GivenTheStudentIsCreated(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7)
        {
            _student = new Student();
            int id = Int32.Parse(p0);
            _student.Id = id;
            _student.FirstName = p1;
            _student.LastName = p2;
            _student.Mail = p3;
            _student.PhoneNumber = p4;
            _student.CycleNumber = Int32.Parse(p7);

            _studentRepository = new Mock<IStudentRepository>();

            _studentRepository.Setup(r => r.FindById(_student.Id))
               .Returns(Task.FromResult<Student>(_student));

        }

        [Given(@"the lesson is created \((.*), (.*), (.*), (.*), (.*), (.*)\)")]
        public void GivenTheLessonIsCreated(string p0, string p1, string p2, string p3, string p4, string p5)
        {
            _lesson = new Lesson();
            lessonType = new LessonType();

            lessonType.Id = 1;
            lessonType.Lessons = new List<Lesson>();
            lessonType.StudentsQuantity = 2;

            _lesson.Id = Int32.Parse(p0);
            _lesson.ScheduleId = Int32.Parse(p1);
            _lesson.Description = p2;
            _lesson.LessonType = lessonType;
            _lesson.LessonTypeId = lessonType.Id;

            lessonType.Lessons.Add(_lesson);

            _lessonRepository = new Mock<ILessonRepository>();
 

            _lessonRepository.Setup(r => r.FindById(_lesson.Id))
                .Returns(Task.FromResult<Lesson>(_lesson));
        }
        
        [When(@"the student signs up for the first time for this lesson")]
        public async Task WhenTheStudentSignsUpForTheFirstTimeForThisLesson()
        {
            _lessonStudent = new LessonStudent();

            _lessonStudent.StudentId = _student.Id;
            _lessonStudent.Student = _student;
            _lessonStudent.LessonId = _lesson.Id;
            _lessonStudent.Lesson = _lesson;
            _lessonStudentRepository = new Mock<ILessonStudentRepository>();


            _lessonStudentRepository.Setup(r => r.FindById(_lessonStudent.LessonId, _lessonStudent.StudentId))
                .Returns(Task.FromResult<LessonStudent>(_lessonStudent));
            _lessonStudentRepository.Setup(r => r.AddAsync(_lessonStudent))
                .Returns(Task.FromResult<LessonStudent>(_lessonStudent));

            _lessonStudentService = new LessonStudentService(_lessonStudentRepository.Object, GetDefaultIUnitOfWorkInstance().Object,
                _lessonRepository.Object, _studentRepository.Object);

            _response = await _lessonStudentService.SaveAsync(_lessonStudent);

        }

        [Then(@"what returns should be (.*)")]
        public void ThenWhatReturnsShouldBe(string p0)
        {
            //    //_lessonStudentRepository.Setup(r => r.AddAsync(_lessonStudent)).Returns(Task.FromResult(_lessonStudent));
            //    string a = _response.Result.Success.ToString();
            Assert.AreEqual(_response.Success.ToString(), p0);
        }

        //  2ND SCENARIO

        [When(@"the student signs up for the second time for this lesson")]
        public async Task WhenTheStudentSignsUpForTheSecondTimeForThisLesson()
        {
            _lessonStudent = new LessonStudent();

            _lessonStudent.StudentId = _student.Id;
            _lessonStudent.Student = _student;
            _lessonStudent.LessonId = _lesson.Id;
            _lessonStudent.Lesson = _lesson;
            _lessonStudentRepository = new Mock<ILessonStudentRepository>();


            _lessonStudentRepository.Setup(r => r.ExistsByLessonIdAndStudentId(_lessonStudent.LessonId, _lessonStudent.StudentId))
                .Returns(Task.FromResult<LessonStudent>(_lessonStudent));

            _lessonStudentService = new LessonStudentService(_lessonStudentRepository.Object, GetDefaultIUnitOfWorkInstance().Object,
                _lessonRepository.Object, _studentRepository.Object);

            _secondResponse = await _lessonStudentService.SaveAsync(_lessonStudent);
        }

        [Then(@"the returned result should be (.*)")]
        public void ThenTheReturnedResultShouldBe(string p0)
        {
            Assert.AreEqual(_secondResponse.Message, p0);
        }

        //3ER SCENARIO
        [When(@"the student signs up for the a lesson that is full")]
        public async Task WhenTheStudentSignsUpForTheALessonThatIsFull()
        {

            _lessonStudent = new LessonStudent();

            _lessonStudent.StudentId = _student.Id;
            _lessonStudent.Student = _student;
            _lessonStudent.LessonId = _lesson.Id;
            _lessonStudent.Lesson = _lesson;
            _lessonStudentRepository = new Mock<ILessonStudentRepository>();
            _lesson.Contador = 2;
            _lessonRepository = new Mock<ILessonRepository>();

            _lessonRepository.Setup(r => r.FindById(_lesson.Id))
                .Returns(Task.FromResult<Lesson>(_lesson));


            _lessonStudentService = new LessonStudentService(_lessonStudentRepository.Object, GetDefaultIUnitOfWorkInstance().Object,
                _lessonRepository.Object, _studentRepository.Object);

            _thirdResponse = await _lessonStudentService.SaveAsync(_lessonStudent);

        }

        [Then(@"the result for this operation should be (.*)")]
        public void ThenTheResultForThisOperationShouldBe(string p0)
        {
            Assert.AreEqual(_thirdResponse.Message, p0);
        }


    }
}