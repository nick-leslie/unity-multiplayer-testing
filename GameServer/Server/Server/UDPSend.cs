using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace Server
{
    class UDPSend
    {
        //TODO cap this to the in game tick speed
        string IP;
        int Port;
       public UDPSend(string _ip,int _port)
        {
            IP = _ip;
            Port = _port;
        }

        public void Send(string pac)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
            UdpClient sender = new UdpClient();
            sender.Connect(endPoint);
            if (pac != null) 
            {
                byte[] sendBytes = Encoding.ASCII.GetBytes(pac);
                sender.Send(sendBytes, sendBytes.Length);
            }
        }
    }
} 
