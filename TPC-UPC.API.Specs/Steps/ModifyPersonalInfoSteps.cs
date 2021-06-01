using Moq;
using System;
using NUnit.Framework;
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
    public class ModifyPersonalInfoSteps
    {
        public readonly ScenarioContext _scenarioContext;
        private Tutor _tutor = new();
        private Tutor _updatedTutor = new();
        private Task<TutorResponse> _response;

        private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

        private static Mock<ILessonRepository> GetDefaultILessonRepositoryInstance()
        {
            return new Mock<ILessonRepository>();
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

        public ModifyPersonalInfoSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        private static Mock<ITutorRepository> _tutorRepository = new Mock<ITutorRepository>();

        private ITutorService _tutorService = new TutorService(_tutorRepository.Object, GetDefaultIFacultyRepositoryInstance().Object,
            GetDefaultIAccountRepositoryInstance().Object, GetDefaultIUnitOfWorkInstance().Object, GetDefaultILessonRepositoryInstance().Object, GetDefaultILessonStudentRepositoryInstance().Object);
        

        [Given(@"I create a new Tutor \((.*), (.*), (.*), (.*), (.*), (.*), (.*)\)")]
        public void GivenICreateANewTutor(string Id, string FirstName, string LastName, string Mail, string PhoneNumber, string AccountId, string FacultyId)
        {
            int realId = Int32.Parse(Id);
            int realAccountId = Int32.Parse(AccountId);
            int realFacultyId = Int32.Parse(FacultyId);
            _tutor.Id = realId;
            _tutor.FirstName = FirstName;
            _tutor.LastName = LastName;
            _tutor.Mail = Mail;
            _tutor.PhoneNumber = PhoneNumber;
            _tutor.AccountId = realAccountId;
            _tutor.FacultyId = realFacultyId;

            _tutorRepository.Setup(r => r.FindById(realId))
               .Returns(Task.FromResult<Tutor>(_tutor));
        }

        [When(@"I Update the info of this Tutor \((.*),(.*), (.*), (.*)\)")]
        public void WhenIUpdateTheInfoOfThisTutor(string Id, string newFirstName, string newLastName, string newPhoneNumber)
        {
            int sameId = Int32.Parse(Id);
            Tutor newTutor = new()
            {
                FirstName = newFirstName,
                LastName = newLastName,
                PhoneNumber = newPhoneNumber
            };
            _response = _tutorService.UpdateAsync(sameId, newTutor);
            Assert.AreEqual(newTutor.FirstName, _response.Result.Resource.FirstName);
        }

        [Then(@"the updated Info should return (.*)")]
        public void ThenTheUpdatedInfoShouldReturn(string actualResponse)
        {
            string a = _response.Result.Success.ToString();
            Assert.AreEqual(a, actualResponse);
        }
    }
}
