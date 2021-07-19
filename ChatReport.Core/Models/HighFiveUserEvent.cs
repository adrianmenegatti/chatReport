using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatReport.Core.Models
{
    public class HighFiveUserEvent : ChatEvent
    {
        readonly User recipient;

        public HighFiveUserEvent(User sender, User recipient, DateTime dateTime) : base(sender, dateTime)
        {
            if (sender == recipient)
                throw new ArgumentException("Sender and recipient could not be the same uwer");

            this.recipient = recipient ?? throw new ArgumentNullException($"Parameter {nameof(recipient)} must be provided.");
        }

        public override string GetDetailedString()
        {
            return $"{User.UserName} high-fived {recipient.UserName}";
        }

        public override string GetShortString(IEnumerable<ChatEvent> events)
        {
            var highFivedEvents = events.Cast<HighFiveUserEvent>();
            var count = highFivedEvents.GroupBy(evt => evt.User).Count();
            var targetUserCount = events.Count();
            var subject = count == 1 ? "person" : "people";
            var subjectTo = targetUserCount == 1 ? "person" : "people";
            
            return $"{count} {subject} high-fived {targetUserCount} other {subjectTo}";
        }
    }
}
