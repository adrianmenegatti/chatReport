using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatReport.Core.Models
{
    public class LeaveTheRoomEvent : ChatEvent
    {
        public LeaveTheRoomEvent(User user, DateTime dateTime) : base(user, dateTime)
        {
        }

        public override string GetDetailedString()
        {
            return $"{User.UserName} left the room";
        }

        public override string GetShortString(IEnumerable<ChatEvent> events)
        {
            return $"{events.Count()} left";
        }
    }
}
