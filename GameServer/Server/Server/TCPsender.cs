using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace Server
{
    static class TCPsender
    {
        static TcpClient sender;
        static string _ip;
        static int _port;
        static bool isSetup=false;
        
         public static void setup(string ip, int port)
         {
            _ip = ip;
            _port = port;
            sender = new TcpClient(_ip, port);
            isSetup = true;
         }
        public static void SendPacket(int CMD,string msg)
        {
            packetCreator creator = new packetCreator();
            send(creator.createPacet(1, CMD, msg));
        }
        static void send(byte[] pac)
        {
            if (isSetup)
            {
                NetworkStream stream = sender.GetStream();
                Console.WriteLine("sending:"+ Encoding.ASCII.GetString(pac));
                stream.Write(pac, 0, pac.Length);
                stream.Flush();
            } else
            {
                //prompt set up
                Console.WriteLine("TCP sender not set up write set up");
                Console.WriteLine("write ip");
                string ip = Console.ReadLine();
                Console.WriteLine("write port");
                int port = Int32.Parse(Console.ReadLine());
                setup(ip,port);
                send(pac);
            }
        }
    }
}
