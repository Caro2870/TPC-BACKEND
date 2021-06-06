using NUnit.Framework;
using Moq;
using FluentAssertions;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Domain.Persistence.Repositories;
using TPC_UPC.Domain.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using TPC_UPC.Services;

namespace TPC_UPC.API.Test
{
    class MeetingServiceTestcs
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task SaveAsyncWhenMeetingsReturnsSuccess()
        {
            //
            var mockMeetingRepository = GetDefaultIMeetingRepositoryInstance();
            var mockIUnitOfWork = GetDefaultIUnitOfWorkInstance();
            Meeting meeting = new Meeting();
            mockMeetingRepository.Setup(r => r.AddAsync(meeting))
                .Returns(Task.FromResult<Meeting>(meeting));
            var service = new MeetingService(mockMeetingRepository.Object, mockIUnitOfWork.Object);
            //
            MeetingResponse result = await service.SaveAsync(meeting);
            var message = result.Message;
            //
            message.Should().Be("");
        }

        private Mock<IMeetingRepository> GetDefaultIMeetingRepositoryInstance()
        {
            return new Mock<IMeetingRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}
