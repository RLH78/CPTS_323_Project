
namespace TargetServerCommunicator.Servers
{
    /// <summary>
    /// Creates a target server object for communicating with the target / game server.
    /// </summary>
    public static class GameServerFactory
    {
        public static IGameServer Create(GameServerType type, string teamName, string ipAddress, int port)
        {
            IGameServer server = null;
            switch (type)
            {
                case GameServerType.WebClient:
                    server = new WebClientGameServerInterface(teamName, ipAddress, port);
                    break;
                case GameServerType.Mock:
                    server = new MockGameServerInterface(teamName, ipAddress, port);
                    break;
            }

            return server;
        }
    }

}
