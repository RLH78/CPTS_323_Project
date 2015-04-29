using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using TargetServerCommunicator.Data;

namespace TargetServerCommunicator
{
    /// <summary>
    /// Communicates with a SAD server.
    /// </summary>
    public abstract class GameServerInterface : IGameServer
    {
        /// <summary>
        /// Route on the server to start a game
        /// </summary>
        protected const string ROUTE_START      = "start";
        /// <summary>
        /// Route on the server to stop a game
        /// </summary>
        protected const string ROUTE_STOP       = "stop";
        /// <summary>
        /// Route on the game server for getting game data 
        /// </summary>
        protected const string ROUTE_GAMES      = "games";
        /// <summary>
        /// Route on the server for getting target data
        /// </summary>
        protected const string ROUTE_TARGETS    = "targets";
        /// <summary>
        /// Name of the team 
        /// </summary>
        protected string m_teamName;

        public GameServerInterface(string teamName, string ipAddress, int port)            
        {            
            IpAddress   = ipAddress;
            Port        = port;
            m_teamName  = teamName;
        }

        public GameServerInterface(string teamName)
            : this(teamName, "10.0.0.8", 3000)
        {
        }

        /// <summary>
        /// Gets or sets the IP address
        /// </summary>
        public string IpAddress { get; set; }
        /// <summary>
        /// Gets or sets the port 
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Downloads data from the route for the request
        /// </summary>
        /// <param name="route"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        protected abstract string DownloadString(string route, string request); 
        /// <summary>
        /// Updates the data to the specified rout.
        /// </summary>
        /// <param name="route"></param>
        /// <param name="values"></param>
        protected abstract void UploadValues(string route,  NameValueCollection values);        
        /// <summary>
        /// Starts the specified game
        /// </summary>
        /// <param name="gameName"></param>
        public void StartGame(string gameName)
        {
            var nameValue   = new NameValueCollection();
            nameValue.Add("teamname", m_teamName);
            nameValue.Add("gamename", gameName);
            UploadValues(ROUTE_START, nameValue);            
        }
        /// <summary>
        /// Stops the current running game.
        /// </summary>
        public void StopRunningGame()
        {
            var nameValue   = new NameValueCollection();
            nameValue.Add("teamname", m_teamName);                
            UploadValues(ROUTE_STOP, nameValue);          
        }        
        /// <summary>
        /// Retrieves the target list for the specified game
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public  IEnumerable<Target> RetrieveTargetList(string game)
        {
            var jsonData = DownloadString(ROUTE_TARGETS, game);
            var data     = JsonConvert.DeserializeObject<List<Target>>(jsonData);
            return data;
        }
        /// <summary>
        /// Retrieves a list of game names
        /// </summary>
        /// <param name="teamName"></param>
        /// <returns></returns>
        public IEnumerable<string> RetrieveGameList()
        {
            var jsonData    = DownloadString(ROUTE_GAMES, "");
            var data        = JsonConvert.DeserializeObject<GameList>(jsonData);
            return data.games;           
        }
    }

}
