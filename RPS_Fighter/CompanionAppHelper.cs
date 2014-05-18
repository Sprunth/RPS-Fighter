using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Fighter
{
    class CompanionAppHelper
    {
        IPEndPoint dest;
        Socket socket;
        UdpClient client;
        Stopwatch stopWatch;

        public CompanionAppHelper()
        {
            
            dest = new IPEndPoint(IPAddress.Parse("128.120.113.190"), 8987);
            socket = new Socket(AddressFamily.InterNetwork,
                                       SocketType.Dgram, ProtocolType.Udp);
            
            /*
            client = new UdpClient();
            dest = new IPEndPoint(IPAddress.Broadcast, 8987);
             * */

            stopWatch = new Stopwatch();
            stopWatch.Start();
        }

        public void Update()
        {
            if (stopWatch.ElapsedMilliseconds > 1000)
            {
                
                string welcome = "Hello, are you there?";
                var data = Encoding.ASCII.GetBytes(welcome);
                socket.SendTo(data, data.Length, SocketFlags.None, dest);
                 
                /*
                byte[] bytes = Encoding.ASCII.GetBytes("Foo");
                client.Send(bytes, bytes.Length, dest);
                //client.Close();
                 * */

                Debug.WriteLine("Sending packet");

                stopWatch.Restart();
            }
        }

    }
}
