using System;

namespace ChatReport.Core.Models
{
    public class User
    {
        public string UserName { get; private set; }

        public User(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException($"Parameter {nameof(userName)} must be provided.");

            UserName = userName;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is User user))
                return false;

            return user.UserName == UserName;
        }

        public override int GetHashCode()
        {
            return UserName.GetHashCode();
        }

        public static bool operator ==(User user1, User user2)
        {
            if (ReferenceEquals(user1, user2))
            {
                return true;
            }
            if (user1 is null || user2 is null) 
            {
                return false;
            }

            return user1.Equals(user2);
        }

        public static bool operator !=(User user1, User user2)
        {
            return !(user1 == user2);
        }
    }
}
