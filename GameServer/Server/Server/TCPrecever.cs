using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Server
{
    class TCPrecever
    {
        int _port;
        TcpListener server;
        packetReader reader;
        Thread receveMsgThread;
        public void start(int port)
        {
            _port = port;
            reader = new packetReader();
            server = new TcpListener(IPAddress.Any, _port);
            Console.WriteLine("starting Server");
            server.Start();
            receveMsgThread = new Thread(receveMsg);
            receveMsgThread.Start();
        }
        void receveMsg()
        {
            while (true)
            {
                Console.WriteLine("waiting For Comand");
                TcpClient client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                byte[] pac = new byte[256];
                try
                {
                    stream.Read(pac, 0, pac.Length);
                } catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                cmdInterpreter.interpretCMD(pac);
                Console.WriteLine(reader.ReadMessage(pac, reader.readHeader(pac)));
            }
        }
    }
}
