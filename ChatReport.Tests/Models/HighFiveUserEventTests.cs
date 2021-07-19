using ChatReport.Core.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ChatReport.Tests.Models
{
    public class HighFiveUserEventTests
    {
        [Fact]
        public void HighFiveUserEventThrowsIfNoSenderIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() => new HighFiveUserEvent(null, new User("test"), new DateTime()));
        }

        [Fact]
        public void HighFiveUserEventThrowsIfNoRecipientIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() => new HighFiveUserEvent(new User("test"), null, new DateTime()));
        }

        [Fact]
        public void HighFiveUserEventThrowsIfSenderAndRecipientAreEqual()
        {
            Assert.Throws<ArgumentException>(() => new HighFiveUserEvent(new User("test"), new User("test"), new DateTime()));
        }

        [Fact]
        public void GetDetailedStringReturnsCorretData()
        {
            var evt = new HighFiveUserEvent(new User("Test"), new User("Other"),  new DateTime());

            Assert.Equal("Test high-fived Other", evt.GetDetailedString());
        }

        [Fact]
        public void GetShortStringReturnsCorrectMessageForOneEvent()
        {
            var evt = new HighFiveUserEvent(new User("Test"), new User("Other"), new DateTime());

            var result = evt.GetShortString(new List<HighFiveUserEvent> { evt });

            Assert.Equal("1 person high-fived 1 other person", result);
        }

        [Fact]
        public void GetShortStringReturnsCorrectMessageForTwoEvents()
        {
            var evt = new HighFiveUserEvent(new User("Test"), new User("Other"), new DateTime());

            var result = evt.GetShortString(new List<HighFiveUserEvent> { evt, evt });

            Assert.Equal("1 person high-fived 2 other people", result);
        }

        [Fact]
        public void GetShortStringReturnsCorrectMessageForMultipleEvents()
        {
            var evt1 = new HighFiveUserEvent(new User("Test 1"), new User("Other1"), new DateTime());
            var evt2 = new HighFiveUserEvent(new User("Test 1"), new User("Other2"), new DateTime());
            var evt3 = new HighFiveUserEvent(new User("Test 2"), new User("Other3"), new DateTime());

            var result = evt1.GetShortString(new List<HighFiveUserEvent> { evt1, evt2, evt3 });

            Assert.Equal("2 people high-fived 3 other people", result);
        }
    }
}
