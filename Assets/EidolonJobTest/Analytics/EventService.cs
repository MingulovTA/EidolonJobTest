using System;
using System.Collections.Generic;
using EidolonJobTest.Extentions;
using EidolonJobTest.RequestsSender;
using EidolonJobTest.ServerProvider;
using ModestTree;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace EidolonJobTest.Analytics
{
    public class EventService : IEventService, ITickable, IDisposable
    {
        private const int SEND_COLDOWN_SECONDS = 1;
        
        private IServerUriProvider _serverUriProvider;
        private IRequestSender _requestSender;

        private bool _transactionInProgress;
        private float _sendTimer;
        private List<Event> _eventsQueue;
        private List<Event> _tempEventsQueue = new List<Event>();
        private EventsCache _eventsCache = new EventsCache();

        [Inject]
        private void Construct(IServerUriProvider serverUriProvider, IRequestSender requestSender)
        {
            _serverUriProvider = serverUriProvider;
            _requestSender = requestSender;
            _eventsQueue = _eventsCache.ResotreEvents();
        }
        
        public void TrackEvent(Event msg)
        {
            msg.AddTo(_transactionInProgress ? _tempEventsQueue : _eventsQueue);
        }

        public void Dispose()
        {
            _eventsCache.CacheEvents(_eventsQueue);
        }

        public void Tick()
        {
            if (_transactionInProgress) return;
            _sendTimer -= Time.deltaTime;
            if (_sendTimer > 0) return;
            _sendTimer = SEND_COLDOWN_SECONDS;
            TryToPackAndSend();
        }

        private void TryToPackAndSend()
        {
            if (_eventsQueue.IsEmpty())
                return;
            _transactionInProgress = true;
            string json = JsonConvert.SerializeObject(_eventsQueue);
            _requestSender.Send(_serverUriProvider.GetUrl(ServerId.Alpha),json,TransactionComplete);
        }

        private void TransactionComplete(TransactionResult result)
        {
            if (result.IsSuccess)
                _eventsQueue.Clear();
            CopyTempEventsToQueue();
            _transactionInProgress = false;
        }

        private void CopyTempEventsToQueue()
        {
            foreach (var msg in _tempEventsQueue)
                msg.AddTo(_eventsQueue);
            _tempEventsQueue.Clear();
        }
    }
}
