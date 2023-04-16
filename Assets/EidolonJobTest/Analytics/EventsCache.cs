using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace EidolonJobTest.Analytics
{
    public class EventsCache
    {
        private string EVENTS_CACHE_PREFS_KEY = "com.analytics.events.cache";
        
        public void CacheEvents(List<Event> events)
        {
            string json = JsonConvert.SerializeObject(events);
            PlayerPrefs.SetString(EVENTS_CACHE_PREFS_KEY,json);
        }

        public List<Event> ResotreEvents()
        {
            if (PlayerPrefs.HasKey(EVENTS_CACHE_PREFS_KEY))
            {
                string json = PlayerPrefs.GetString(EVENTS_CACHE_PREFS_KEY);
                return JsonConvert.DeserializeObject<List<Event>>(json);
            }
            else
            {
                return new List<Event>();
            }
        }
    }
}
