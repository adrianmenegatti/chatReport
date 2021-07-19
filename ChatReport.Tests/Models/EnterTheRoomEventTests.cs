using ChatReport.Core.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ChatReport.Tests.Models
{
    public class EnterTheRoomEventTests
    {
        [Fact]
        public void EnterTheRoomEventThrowsIfNoUserProvided()
        {
            Assert.Throws<ArgumentNullException>(() => new EnterTheRoomEvent(null, new DateTime()));
        }

        [Fact]
        public void GetDetailedStringReturnsCorretData()
        {
            var evt = new EnterTheRoomEvent(new User("Test"), new DateTime());

            Assert.Equal("Test entered the room", evt.GetDetailedString());
        }

        [Fact]
        public void GetShortStringReturnsCorrectMessageForOneEvent()
        {
            var evt = new EnterTheRoomEvent(new User("Test"), new DateTime());

            var result = evt.GetShortString(new List<EnterTheRoomEvent> { evt });

            Assert.Equal("1 person entered", result);
        }

        [Fact]
        public void GetShortStringReturnsCorrectMessageForTwoEvents()
        {
            var evt = new EnterTheRoomEvent(new User("Test"), new DateTime());

            var result = evt.GetShortString(new List<EnterTheRoomEvent> { evt, evt });

            Assert.Equal("2 people entered", result);
        }
    }
}
