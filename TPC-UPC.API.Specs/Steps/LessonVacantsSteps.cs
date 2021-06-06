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
    public sealed class LessonVacantsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private Lesson lesson;
        private LessonType lessonType;
        private Mock<ILessonRepository> mockLessonRepository;
        private Mock<ILessonTypeRepository> mockLessonTypeRepository;
        private Mock<IUnitOfWork> mockUnitOfWork;
        private LessonResponse result;
        public LessonVacantsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a Lesson ""(.*)""")]
        public void GivenALesson(string p0)
        {

            lesson = new Lesson();
            lesson.Id = 1;
            lesson.Vacants = 2;
            lessonType = new LessonType();
            lessonType.Id = 2;
            lessonType.StudentsQuantity = 0;
        }


        //SCENARIO 1
        [Given(@"I am in the lesson section")]
        public void GivenIAmInTheLessonSection()
        {
            mockLessonRepository     = GetDefaultILessonRepositoryInstance();
            mockLessonTypeRepository = GetDefaultLessonTypeRepositoryInstance();
            mockUnitOfWork = GetDefaultIUnitOfWorkInstance();


            mockLessonRepository.Setup(r => r.FindById(lesson.Id)).ReturnsAsync(lesson);
            mockLessonTypeRepository.Setup(r => r.FindById(lessonType.Id)).ReturnsAsync(lessonType);
        }

        [When(@"I see the lesson description")]
        public async void WhenISeeTheLessonDescription()
        {
            var service = new LessonService(mockLessonRepository.Object, mockUnitOfWork.Object);
            result = await service.GetByIdAsync(lesson.Id);
        }

        [Then(@"I should see the number of vacants")]
        public void ThenIShouldSeeTheNumberOfVacants()
        {
            result.Resource.Vacants.Should().Be(2);
        }

        //SCENARIO 2
        [Given(@"I am in the lesson section__")]
        public void GivenIAmInTheLessonSection__()
        {
            mockLessonRepository = GetDefaultILessonRepositoryInstance();
            mockLessonTypeRepository = GetDefaultLessonTypeRepositoryInstance();
            mockUnitOfWork = GetDefaultIUnitOfWorkInstance();

            lesson.Vacants = 2;
            lessonType.StudentsQuantity = 2;
            mockLessonRepository.Setup(r => r.FindById(lesson.Id)).ReturnsAsync(lesson);
            mockLessonTypeRepository.Setup(r => r.FindById(lessonType.Id)).ReturnsAsync(lessonType);
        }

        [When(@"I see the lesson description__")]
        public async void WhenISeeTheLessonDescription__()
        {
            var service = new LessonService(mockLessonRepository.Object, mockUnitOfWork.Object);
            result = await service.GetByIdAsync(lesson.Id);
        }

        [Then(@"I should--SEE ""(.*)""")]
        public void ThenIShould_SEE(string p0)
        {
            var vacants = result.Resource.Vacants;
            var message = "";
            if (lessonType.StudentsQuantity == result.Resource.Vacants)
            {
                message = p0;
            }
            message.Should().Be(p0);
        }


        private Mock<ILessonTypeRepository> GetDefaultLessonTypeRepositoryInstance()
        {
            return new Mock<ILessonTypeRepository>();
        }
        private Mock<ILessonRepository> GetDefaultILessonRepositoryInstance()
        {
            return new Mock<ILessonRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
