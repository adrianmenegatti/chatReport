using ChatReport.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChatReport.Tests.Models
{
    public class LeaveTheRoomEventTests
    {
        [Fact]
        public void CommentEventThrowsIfNoUserIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() => new LeaveTheRoomEvent(null, new DateTime()));
        }

        [Fact]
        public void GetDetailedStringReturnsCorretData()
        {
            var evt = new LeaveTheRoomEvent(new User("Test"), new DateTime());

            Assert.Equal("Test left the room", evt.GetDetailedString());
        }

        [Fact]
        public void GetShortStringReturnsCorrectData()
        {
            var evt = new LeaveTheRoomEvent(new User("Test"), new DateTime());

            var result = evt.GetShortString(new List<LeaveTheRoomEvent> { evt, evt });

            Assert.Equal("2 left", result);
        }

    }
}
