using ChatReport.Core.Models;
using ChatReport.Core.Services;
using ChatReport.Data.Repositories;
using ChatReport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ChatReport.Tests.Services
{
    public class ChatReportServiceTests
    {
        private readonly IChatReportService service;
        private readonly DateTime date = new DateTime(2021, 6, 1);

        public ChatReportServiceTests()
        {
            var repository = new ChatEventsRepository();
            service = new ChatReportService(repository);
        }

        [Fact]
        public void GetReportReturnsEmptyListForInvalidDate()
        {
            var result = service.GetReport(new DateTime(2021, 6, 10), AggregationType.Hourly);

            Assert.Empty(result);
        }

        [Fact]
        public void GetReportReturnsNonEmptyListForValidDate()
        {
            var result = service.GetReport(date, AggregationType.MinuteByMinute);

            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetReportReturnsCorrectDataForMinuteByMinuteAggregationType()
        {
            var result = service.GetReport(date, AggregationType.MinuteByMinute);

            Assert.Equal("Bob entered the room", result.First().Event);
        }

        [Fact]
        public void GetReportReturnsCorrectDataForHourlyAggregationType()
        {
            var result = service.GetReport(date, AggregationType.Hourly);

            Assert.Equal("2 people entered", result.First().Event);
        }
    }
}
