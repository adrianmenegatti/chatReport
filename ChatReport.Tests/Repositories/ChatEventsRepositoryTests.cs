using ChatReport.Core.Repositories;
using ChatReport.Data.Repositories;
using System;
using System.Linq;
using Xunit;

namespace ChatReport.Tests.Repositories
{
    public class ChatEventsRepositoryTests
    {
        private readonly IChatEventsRepository repository;
        private DateTime date;

        public ChatEventsRepositoryTests()
        {
            repository = new ChatEventsRepository();
            date = new DateTime(2021, 6, 2);
        }

        [Fact]
        public void GetEventsReturnsEventsListForTheGivenDate()
        {
            var events = repository.GetEvents(date);

            Assert.True(events.All(e => e.DateTime.Date == date));
        }

        [Fact]
        public void GetEventsReturnsOrderedEventsList()
        {
            var events = repository.GetEvents(date);

            Assert.True(events.Zip(events.Skip(1), (a, b) => a.DateTime < b.DateTime).All(x => true));
        }
    }
}
