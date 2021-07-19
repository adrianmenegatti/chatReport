using System;
using System.Collections.Generic;

namespace ChatReport.Core.Models
{
    public abstract class ChatEvent
    {
        public DateTime DateTime { get; private set; }
        public User User { get; private set; }

        public ChatEvent(User user, DateTime dateTime)
        {
            User = user ?? throw new ArgumentNullException($"Parrameter {nameof(user)} must be provided.");
            DateTime = dateTime; ;
        }

        public abstract string GetDetailedString();
        public abstract string GetShortString(IEnumerable<ChatEvent> events);
    }
}
