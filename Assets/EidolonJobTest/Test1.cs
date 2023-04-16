using EidolonJobTest.Analytics;
using UnityEngine;
using Zenject;
using Event = EidolonJobTest.Analytics.Event;

namespace EidolonJobTest
{
    public class Test1 : MonoBehaviour
    {
        private IEventService _eventService;

        [Inject]
        private void Construct(IEventService eventService)
        {
            _eventService = eventService;
        }

        private void Awake()
        {
            _eventService.TrackEvent(new Event("scope","msg1"));
            _eventService.TrackEvent(new Event("scope","msg2"));
        }
    }
}
