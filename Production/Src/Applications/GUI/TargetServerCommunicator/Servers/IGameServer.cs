using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetServerCommunicator.Data;

namespace TargetServerCommunicator
{
    /// <summary>
    /// Interface
    /// </summary>
    public interface IGameServer
    {
        /// <summary>
        /// Starts the specified game
        /// </summary>
        /// <param name="game"></param>
        void StartGame(string game); 
        /// <summary>
        /// Stops the current running game.
        /// </summary>
        void StopRunningGame();
        IEnumerable<Target> RetrieveTargetList(string game);
        /// <summary>
        /// Retrieves a list of game names
        /// </summary>
        /// <param name="teamName"></param>
        /// <returns></returns>
        IEnumerable<string> RetrieveGameList();
    }
}
