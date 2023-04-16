using System.Collections.Generic;

namespace EidolonJobTest.ServerProvider
{
    public class ServerUriProvider : IServerUriProvider
    {
        private readonly Dictionary<ServerId, string> _serversUrls = new Dictionary<ServerId, string>
        {
            {ServerId.Alpha,""},
            {ServerId.Prod,""},
            {ServerId.BackupServer,""},
        };

        public string GetUrl(ServerId serverId)
        {
            if (_serversUrls.ContainsKey(serverId))
                return _serversUrls[serverId];
            return _serversUrls[ServerId.Alpha];
        }
    }
}
