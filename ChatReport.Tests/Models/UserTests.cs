using ChatReport.Core.Models;
using System;
using Xunit;

namespace ChatReport.Tests.Models
{
    public class UserTests
    {
        [Fact]
        public void UserThrowsIfNoUsernameIsProvided()
        {
            Assert.Throws<ArgumentNullException>(() => new User(""));
        }

        [Fact]
        public void TwoUsersWithTheSameUserNameAreEqual()
        {
            var user1 = new User("Test");
            var user2 = new User("Test");

            Assert.True(user1 == user2);
            Assert.True(user1.Equals(user2));
            Assert.False(user1 != user2);
        }
    }
}
