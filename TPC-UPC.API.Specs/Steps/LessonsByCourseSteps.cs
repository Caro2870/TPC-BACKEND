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
    public sealed class LessonsByCourseSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private LessonService _lessonService;
        private Task<LessonResponse> _response;
        private Mock<ILessonService> mockLessonService;
        private IEnumerable<LessonResource> _okResult;
        private Mock<IMapper> mockMapper;
        private LessonController _controller;
        private SuggestionResource suggestionResource;
        private Course course;

        public LessonsByCourseSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a course Id with number ""(.*)""")]
        public void GivenACourseIdWithNumber(int p0)
        {
            course = new Course { Id = 1, Name = "Programacion 1", Credits = 2 };
        }

        [Given(@"I am in the finding tutorials section q")]
        public void GivenIAmInTheFindingTutorialsSectionQ()
        {
            mockMapper = GetDefaultMapperInstance();
            mockLessonService = GetDefaultLessonServiceInstance();

            List<Lesson> lessons = new List<Lesson>()
            {
                new Lesson{ Id = 2, CourseId = 1, Course = course, MeetingLink = "hola.com"},
                new Lesson{ Id = 3, CourseId = 1, Course = course, MeetingLink = "tamalitos.com"},
            };
            IEnumerable<LessonResource> lessonResources = new List<LessonResource>()
            {
                new LessonResource{ Id = 2, MeetingLink = "hola.com"},
                new LessonResource{ Id = 3, MeetingLink = "tamalitos.com"},
            };
            mockLessonService.Setup(r => r.ListByCourseIdAsync(course.Id)).ReturnsAsync(lessons);
            mockMapper.Setup(r => r.Map<IEnumerable<Lesson>, IEnumerable<LessonResource>>(lessons)).Returns(lessonResources);
        }

        [When(@"I try to look for a tutorial in a course q")]
        public async void WhenITryToLookForATutorialInACourseQ()
        {
            _controller = new LessonController(mockLessonService.Object, mockMapper.Object);
            _okResult = await _controller.ListByCourseIdAsyncx(course.Id);
        }

        [Then(@"I should see all the Tutorials on the courseq")]
        public void ThenIShouldSeeAllTheTutorialsOnTheCourseq()
        {
            ((List<LessonResource>)_okResult).Count.Should().BeGreaterThan(0);
        }

        [Given(@"I am in the finding tutorials section a")]
        public void GivenIAmInTheFindingTutorialsSectionA()
        {
            mockMapper = GetDefaultMapperInstance();
            mockLessonService = GetDefaultLessonServiceInstance();

            List<Lesson> lessons = new List<Lesson>()
            {};
            IEnumerable<LessonResource> lessonResources = new List<LessonResource>()
            {};
            mockLessonService.Setup(r => r.ListByCourseIdAsync(course.Id)).ReturnsAsync(lessons);
            mockMapper.Setup(r => r.Map<IEnumerable<Lesson>, IEnumerable<LessonResource>>(lessons)).Returns(lessonResources);

        }

        [When(@"I try to look for a tutorial in a course a")]
        public async void WhenITryToLookForATutorialInACourseA()
        {
            _controller = new LessonController(mockLessonService.Object, mockMapper.Object);
            _okResult = await _controller.ListByCourseIdAsyncx(course.Id);

        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string p0)
        {
            string message = "";
            if (((List<LessonResource>)_okResult).Count == 0)
            {
                message = p0;
            }
            message.Should().Be(p0);
        }


        private Mock<ILessonService> GetDefaultLessonServiceInstance()
        {
            return new Mock<ILessonService>();
        }

        private Mock<IMapper> GetDefaultMapperInstance()
        {
            return new Mock<IMapper>();
        }
    }
}
