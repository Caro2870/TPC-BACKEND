using Moq;
using NUnit.Framework;
using System;
using AutoMapper;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Resources;
using TPC_UPC.Services;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Microsoft.AspNetCore.Mvc;
using TPC_UPC.Controllers;
using FluentAssertions;

namespace TPC_UPC.API.Specs.Steps
{
    [Binding]
    public sealed class SuggestionSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private SuggestionService _suggestionService;
        private Task<SuggestionResponse> _response;
        private Mock<ISuggestionService> mockSuggestionService;
        private IEnumerable<SuggestionResource> _okResult;
        private Mock<IMapper> mockMapper;
        private SuggestionsController _controller;
        private SuggestionResource suggestionResource;
        public SuggestionSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am in the suggestions section")]
        public void GivenIAmInTheSuggestionsSection()
        {
            mockMapper = GetDefaultMapperInstance();
            mockSuggestionService = GetDefaultSuggestionServiceInstance();

            List<Suggestion> suggestions = new List<Suggestion>()
            {
                new Suggestion {Id = 1, Message = "Tamarindo tamalin", UserId = 104},
                new Suggestion {Id = 2, Message = "Empaquetado de tamarindo", UserId = 101}
            };
            IEnumerable<SuggestionResource> suggestionResources = new List<SuggestionResource>()
            {
                new SuggestionResource {Id = 1, Message = "Tamarindo tamalin"},
                new SuggestionResource {Id = 2, Message = "Empaquetado de tamarindo"}
            };

            mockSuggestionService.Setup(r => r.ListAsync()).ReturnsAsync(suggestions);
            mockMapper.Setup(r => r.Map<IEnumerable<Suggestion>, IEnumerable<SuggestionResource>>(suggestions)).Returns(suggestionResources);
        }

        [When(@"I try to look up all the suggestions")]
        public async void WhenITryToLookUpAllTheSuggestions()
        {
            _controller = new SuggestionsController(mockSuggestionService.Object, mockMapper.Object);
            _okResult = await _controller.GetAllAsync();
        }

        [Then(@"the system should show me all the suggestions")]
        public void ThenTheSystemShouldShowMeAllTheSuggestions()
        {
            ((List<SuggestionResource>)_okResult).Count.Should().BeGreaterThan(0);
        }



        [Given(@"I am in the suggestions section \(t\)")]
        public void GivenIAmInTheSuggestionsSectionT()
        {
            mockMapper = GetDefaultMapperInstance();
            mockSuggestionService = GetDefaultSuggestionServiceInstance();

            List<Suggestion> suggestions = new List<Suggestion>()
            {
            };
            IEnumerable<SuggestionResource> suggestionResources = new List<SuggestionResource>()
            {
            };

            mockSuggestionService.Setup(r => r.ListAsync()).ReturnsAsync(suggestions);
            mockMapper.Setup(r => r.Map<IEnumerable<Suggestion>, IEnumerable<SuggestionResource>>(suggestions)).Returns(suggestionResources);

        }

        [When(@"I try to look up all the suggestions \(t\)")]
        public async void WhenITryToLookUpAllTheSuggestionsT()
        {
            _controller = new SuggestionsController(mockSuggestionService.Object, mockMapper.Object);
            _okResult = await _controller.GetAllAsync();
        }

        [Then(@"I should SEE ""(.*)""")]
        public void ThenIShouldSEE(string p0)
        {
            var cont = ((List<SuggestionResource>)_okResult).Count;
            var message = "";
            if (cont == 0)
            {
                message = p0;
            }
            message.Should().Be(p0);
        }


        private Mock<ISuggestionService> GetDefaultSuggestionServiceInstance()
        {
            return new Mock<ISuggestionService>();
        }

        private Mock<IMapper> GetDefaultMapperInstance()
        {
            return new Mock<IMapper>();
        }
    }
}



