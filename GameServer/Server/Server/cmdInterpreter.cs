using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    static class cmdInterpreter
    {
        public const int maxPlayers = 4;
        public static int currentReadyPlayers = 0;
        public static int currentPlayers = 0;
        public static void interpretCMD(byte[] pac)
        {
            packetReader reader = new packetReader();
            reader.readPacet(pac);
            switch (reader.readCMD(pac)) 
            {
                //start up a new setion/assine user id
                case 0:
                    currentPlayers +=1;
                    roomManiger.addUser(currentPlayers, reader.ReadMessage(pac, reader.readHeader(pac)));
                    TCPsender.SendPacket(0,currentPlayers.ToString());
                    break;
                //change user Name
                case 1:
                    roomManiger.changeUserName(reader.ReadUserID(pac), reader.ReadMessage(pac, reader.readHeader(pac)));
                    TCPsender.SendPacket(1, reader.ReadMessage(pac, reader.readHeader(pac)));
                    break;
                //send message
                case 2:
                    break;
                //3 disconet user
                case 3:
                    break;
                // ready up user comand
                case 4:
                    Console.WriteLine("case 4 triped");
                    currentReadyPlayers += 1;
                    if (currentReadyPlayers == maxPlayers)
                    {
                        TickHandler.setup();
                        break;
                    }
                    break;
                case 5: //force full start host only
                    Console.WriteLine("case 5 triped");
                    TickHandler.setup();
                    break;
            }
        }
    }
}
