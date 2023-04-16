namespace EidolonJobTest.Analytics
{
    public class Event
    {
        public string type;
        public string data;

        public Event(string type, string data)
        {
            this.type = type;
            this.data = data;
        }
    }
}
