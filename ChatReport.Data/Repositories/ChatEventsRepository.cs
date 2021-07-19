using ChatReport.Core.Models;
using ChatReport.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatReport.Data.Repositories
{
    public class ChatEventsRepository : IChatEventsRepository
    {
        private List<ChatEvent> chatEvents;

        public ChatEventsRepository()
        {
            CreateEventsList();
        }

        public IEnumerable<ChatEvent> GetEvents(DateTime dateTime)
        {
            return chatEvents.Where(evt => evt.DateTime.Date == dateTime.Date).OrderBy(evt => evt.DateTime);
        }

        private void CreateEventsList()
        {
            var bob = new User("Bob");
            var kate = new User("Kate");
            var martin = new User("Martin");
            var sara = new User("Sara");

            chatEvents = new List<ChatEvent>
            {
                new EnterTheRoomEvent(bob, new DateTime(2021,6,1,17,0,0)),
                new EnterTheRoomEvent(kate, new DateTime(2021,6,1,17,5,0)),
                new CommentEvent(bob, "Hey, Kate - high five?", new DateTime(2021,6,1,17,15,0)),
                new HighFiveUserEvent(kate, bob, new DateTime(2021,6,1,17,17,0)),
                new LeaveTheRoomEvent(bob, new DateTime(2021,6,1,17,18,0)),
                new CommentEvent(kate, "Oh, typical", new DateTime(2021,6,1,17,20,0)),
                new LeaveTheRoomEvent(kate, new DateTime(2021,6,1,17,21,0)),

                new EnterTheRoomEvent(martin, new DateTime(2021,6,2,17,0,0)),
                new EnterTheRoomEvent(sara, new DateTime(2021,6,2,17,0,0)),
                new EnterTheRoomEvent(kate, new DateTime(2021,6,2,17,5,0)),
                new CommentEvent(martin, "Hey, Kate - high five?", new DateTime(2021,6,2,17,15,0)),
                new CommentEvent(martin, "Hey, Sara - high five?", new DateTime(2021,6,2,17,15,0)),
                new EnterTheRoomEvent(bob, new DateTime(2021,6,2,17,0,0)),
                new HighFiveUserEvent(bob, kate, new DateTime(2021,6,2,17,17,0)),
                new HighFiveUserEvent(bob, sara, new DateTime(2021,6,2,17,17,0)),
                new LeaveTheRoomEvent(martin, new DateTime(2021,6,2,18,18,0)),
                new CommentEvent(kate, "Oh, typical", new DateTime(2021,6,2,17,20,0)),
                new LeaveTheRoomEvent(kate, new DateTime(2021,6,2,18,21,0)),
                new CommentEvent(martin, "Nobody there?", new DateTime(2021,6,2,18,10,0)),
                new CommentEvent(martin, "Ok", new DateTime(2021,6,2,18,11,0)),

            };
        }
    }
}