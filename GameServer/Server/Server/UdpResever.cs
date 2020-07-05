using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
namespace Server
{
    class UdpResever
    {
        UdpClient server;
        IPEndPoint acesss;
        private const int listenPort = 11000;
        public UdpResever(int port) 
        {

        }

       public void Reseve()
        {
            acesss = new IPEndPoint(IPAddress.Any, listenPort);
            server = new UdpClient(listenPort);
            while (true)
            {
                byte[] resevedBytes = server.Receive(ref acesss);
                Console.WriteLine(Encoding.ASCII.GetString(resevedBytes));
            }
        }
    }
}
