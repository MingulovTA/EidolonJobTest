using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EidolonJobTest.Analytics
{
    public class EventService : IEventService, ITickable, IInitializable, IDisposable
    {
        private const int SEND_COLDOWN_SECONDS = 2;

        private float _sendTimer;
        private List<Event> _eventsQueue;
        private EventsCache _eventsCache = new EventsCache();
        
        public void TrackEvent(Event @event)
        {
            _eventsQueue.Add(@event);
        }
        
        public void Initialize()
        {
            _eventsQueue = _eventsCache.ResotreEvents();
        }

        public void Dispose()
        {
            _eventsCache.CacheEvents(_eventsQueue);
        }

        public void Tick()
        {
            _sendTimer -= Time.deltaTime;
            if (_sendTimer > 0) return;
            _sendTimer = SEND_COLDOWN_SECONDS;
            TryToPackAndSend();
        }

        private void TryToPackAndSend()
        {
            
        }


    }
}
