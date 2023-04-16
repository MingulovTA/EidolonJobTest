
namespace EidolonJobTest.ServerProvider
{
    public interface IServerUriProvider
    {
        public string GetUrl(ServerId serverId);
    }
}
