using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatReport.Core.Models
{
    public class CommentEvent : ChatEvent
    {
        readonly string message;
        public CommentEvent(User user, string message, DateTime dateTime) : base(user, dateTime)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException($"{nameof(message)} should be provided");

            this.message = message;
        }

        public override string GetDetailedString()
        {
            return $"{User.UserName} commented: {message}";
        }

        public override string GetShortString(IEnumerable<ChatEvent> events)
        {
            return $"{events.Count()} comments";
        }
    }
}
