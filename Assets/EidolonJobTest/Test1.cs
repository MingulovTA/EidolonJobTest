using System;
using System.Collections;
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
            _eventService.TrackEvent(new Event("scope","Awake"));
        }

        private IEnumerator Start()
        {
            _eventService.TrackEvent(new Event("scope","Start"));
            yield return null;
            _eventService.TrackEvent(new Event("scope","Hello world"));
            yield return new WaitForSeconds(2f);
            _eventService.TrackEvent(new Event("scope","Bye world"));
        }
    }
}
