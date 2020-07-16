using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
namespace Server
{
   static class TickHandler
    {
        //this is the time between ticks in miliseconds 17
        private const int timeBetweenTicks=16;
        private static bool isRunning = false;
        static public void setup() 
        {
            if (isRunning==false)
            {
                Console.WriteLine("set up function start");
                int Tick = 0;
                Timer UpdateTick = new Timer();
                UpdateTick.Interval = timeBetweenTicks;
                UpdateTick.Enabled = true;
                UpdateTick.Elapsed += (sender, e) => TimerEvent(sender, e,ref Tick);
                isRunning = true;
            }
        }
        private static void TimerEvent(object sender, ElapsedEventArgs e,ref int tick)
        {
            tick++;
            send(tick);
            //Console.WriteLine("Tick:"+tick);
        }
        static void send(int tick)
        {
            UDPSend sender = new UDPSend("127.0.0.1", 12000);
            sender.Send(packetBuffer.Getlast());
            packetBuffer.RemoveLast();
            //Console.WriteLine("Server Tick:"+tick.ToString());
        }
    }
}
