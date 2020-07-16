using System;
using System.Threading;
namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //started udp receving
            UdpResever resever = new UdpResever(11000);
            resever.start();

            //TCP sending
            TCPsender.setup("127.0.0.1",1235);
            TCPsender.SendPacket(0, "this is a test message");
            //tcp reseving
            TCPrecever recever = new TCPrecever();
            recever.start(1234);
        }
    }
}
