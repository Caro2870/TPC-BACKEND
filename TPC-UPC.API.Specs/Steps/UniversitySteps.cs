using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Resources;
using TPC_UPC.Services;

namespace TPC_UPC.API.Specs.Steps
{
    [Binding]
    public sealed class UniversitySteps
    {
        public readonly ScenarioContext _scenarioContext;
        private University _university = new();
        private Task<UniversityResponse> _response;

        private static Mock<IUniversityRepository> GetDefaultIUniversityRepositoryInstance()
        {
            return new Mock<IUniversityRepository>();
        }

        private static Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }

        private IUniversityService _universityService = new UniversityService(GetDefaultIUniversityRepositoryInstance().Object, GetDefaultIUnitOfWorkInstance().Object);

        public UniversitySteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I  create  a  new  University  \((.*), (.*)\)")]
        public void GivenICreateANewUniversity(string id, string universityName)
        {
            int realId = Int32.Parse(id);
            _university.Id = realId;
            _university.UniversityName = universityName;
            _response = _universityService.SaveAsync(_university);
        }

        //[Given(@"I  create  a  new  University  (.*)")]
        //public void GivenICreateANewUniversity(int id, string universityName)
        //{
        //    _university.UniversityName = universityName;

        //    var mockUniversityRepository = GetDefaultIUniversityRepositoryInstance();
        //    var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
        //    var mockUniversityService = new UniversityService(mockUniversityRepository.Object, mockIUnitOfWork.Object);
        //    var mockUniversityController = new UniversitiesController(mockUniversityService, _mapper);

        //    _result = mockUniversityController.PostAsync(_university);
        //}

        [Then(@"the  system  should  return  (.*)")]
        public void ThenTheSystemShouldReturn(string responseCode)
        {
            string a = _response.Result.Success.ToString();
            Assert.AreEqual(a, responseCode);
        }
    }
}