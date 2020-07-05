using System;

namespace Server
{
    class Programswe
    {

        static void Main(string[] args)
        {
            //TODO impliment the main tick system for sending of packets 
            send(); 
        }
       static void send()
        {
            UDPSend sender = new UDPSend("127.0.0.1", 12000);
            int i = 0;
            while (true)
            {
                sender.Send(i.ToString());
                Console.WriteLine(i.ToString());
                i++;
            }
        }
        void recve()
        {
            UdpResever resever = new UdpResever(11000);
            resever.Reseve();
        }
    }
}
