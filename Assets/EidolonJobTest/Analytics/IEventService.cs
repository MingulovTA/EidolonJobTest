namespace EidolonJobTest.Analytics
{
    public interface IEventService
    {
        public void TrackEvent(Event @event);
    }
}
