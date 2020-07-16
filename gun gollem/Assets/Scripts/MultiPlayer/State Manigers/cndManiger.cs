using System.Collections;
using System.Collections.Generic;
using System;
public static class cndManiger
{
   public static void interpretCMD(byte[] pac)
    {
        packetReader reader = new packetReader();
        switch(reader.readCMD(pac))
        {
            //set up personal aka assine personal user id 
            case 0:
                int userid = Int16.Parse(reader.ReadMessage(pac, reader.readHeader(pac)));
                roomManiger.setUserId(userid);
                break;
            // change other user id
            case 1:
                break;
            // msg
            case 2:
                break;
            // disconect
            case 3:
                break;
            //readyed user
            case 4:
                break;
            //add new person to room
            case 5:
                roomManiger.currentPlayers += 1;
                //add all users to a list 
                break;
        }
    } 
}
