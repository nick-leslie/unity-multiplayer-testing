using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
namespace Server
{
    class UdpResever
    {
        UdpClient server;
        IPEndPoint acesss;
        private int listenPort;
        Thread receiveThread;
        public UdpResever(int port) 
        {
            listenPort = port;
        }
        public void start()
        {
            receiveThread = new Thread(receive);
            receiveThread.Start();
        }
       public void receive()
        {
            acesss = new IPEndPoint(IPAddress.Any, listenPort);
            server = new UdpClient(listenPort);
            while (true)
            {
                byte[] resevedBytes = server.Receive(ref acesss);
                string pac = Encoding.ASCII.GetString(resevedBytes);
                packetBuffer.setFirst(pac);
                Console.WriteLine(pac);
            }
        }
    }
}
