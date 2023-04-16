using EidolonJobTest.Extentions;
using UnityEngine;

namespace EidolonJobTest.Analytics
{
    public class EventService : IEventService
    {
        public void TrackEvent(Event @event)
        {
            $"event here: {@event.type},{@event.data}".LogEditor(Color.cyan);
        }
    }
}
