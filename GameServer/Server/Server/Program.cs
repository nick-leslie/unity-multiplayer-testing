using System;
using System.Threading;
namespace Server
{
    class Programswe
    {
        static void Main(string[] args)
        {
            TickHandler timingHandler = new TickHandler();
            UdpResever resever = new UdpResever(11000);
            resever.start();
            timingHandler.setup();

        }
    }
}
