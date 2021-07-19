using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatReport.Core.Models
{
    public class EnterTheRoomEvent : ChatEvent
    {
        public EnterTheRoomEvent(User user, DateTime dateTime) : base(user, dateTime)
        {
        }

        public override string GetDetailedString()
        {
            return $"{User.UserName} entered the room";
        }

        public override string GetShortString(IEnumerable<ChatEvent> events)
        {
            var count = events.Count();
            var subject = count == 1 ? "person" : "people";

            return $"{count} {subject} entered";
        }
    }
}
