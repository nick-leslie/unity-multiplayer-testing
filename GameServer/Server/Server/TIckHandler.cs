using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
namespace Server
{
    class TickHandler
    {
       public void setup() 
        {
            int Tick = 0;
            Timer UpdateTick = new Timer();
            UpdateTick.Interval = 100;
            UpdateTick.Enabled = true;
            UpdateTick.Elapsed += (sender, e) => TimerEvent(sender, e,ref Tick);
        }
        private static void TimerEvent(object sender, ElapsedEventArgs e,ref int tick)
        {
            tick++;
            send(tick);
        }
        static void send(int tick)
        {
            UDPSend sender = new UDPSend("127.0.0.1", 12000);
            sender.Send(packetBuffer.Getlast());
            packetBuffer.RemoveLast();
            Console.WriteLine("Server Tick:"+tick.ToString());
        }
    }
}
