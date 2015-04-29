using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetServerCommunicator.Data
{
    /// <summary>
    /// Json mirror for data
    /// </summary>
    public class GameList
    {
        /// <summary>
        /// Gets or sets the list of available games.
        /// </summary>
        public IList<string> games { get; set; }
    }
}
