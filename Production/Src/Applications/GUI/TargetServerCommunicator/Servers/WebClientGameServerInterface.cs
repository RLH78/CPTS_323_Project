using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TargetServerCommunicator
{
    public class WebClientGameServerInterface : GameServerInterface
    {

        public WebClientGameServerInterface(string teamName)
            : base(teamName)
        {

        }

        public WebClientGameServerInterface(string teamName, string ipAddress, int port)
            : base(teamName, ipAddress, port)
        {

        }

        protected override string DownloadString(string route, string request)
        {
            var data = "";
            string baseHost = string.Format("http://{0}:{1}/{2}/{3}", IpAddress, Port, route, request);
            using (var client = new WebClient())
            {
                data = client.DownloadString(baseHost);                
            }
            return data;
        }
        /// <summary>
        /// Uploads data to the specified route.
        /// </summary>
        /// <param name="route"></param>
        /// <param name="values"></param>
        protected override void UploadValues(string route, NameValueCollection values)
        {
            string baseHost = string.Format("http://{0}:{1}/{2}", IpAddress, Port, route);
            using (var client = new WebClient())
            {
                client.UploadValues(baseHost, values);
            }
        }
    }

    
}
