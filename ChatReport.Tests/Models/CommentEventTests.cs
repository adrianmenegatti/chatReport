using ChatReport.Core.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ChatReport.Tests.Models
{
    public class CommentEventTests
    {
        [Fact]
        public void CommentEventThrowsIfNoUserIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() => new CommentEvent(null, "jkjkj", new DateTime()));
        }

        [Fact]
        public void CommentEventThrowsIfNoMessageIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() => new CommentEvent(new User("Test"), "", new DateTime()));
        }

        [Fact]
        public void GetDetailedStringReturnsCorretData()
        {
            var evt = new CommentEvent(new User("Test"), "Test comment", new DateTime());

            Assert.Equal("Test commented: Test comment", evt.GetDetailedString());
        }

        [Fact]
        public void GetShortStringReturnsCorrectData()
        {
            var evt = new CommentEvent(new User("Test"), "Test comment", new DateTime());

            var result = evt.GetShortString(new List<CommentEvent> { evt, evt });

            Assert.Equal("2 comments", result);
        }
    }
}
