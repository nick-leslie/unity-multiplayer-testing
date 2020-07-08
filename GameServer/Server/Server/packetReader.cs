using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class packetReader
    {
        int headerSize = 10;
        int userIDLength = 2;
        int Mesagelength;
        int packetVarificationLength = 4;
        int cmdByteNum = 1;
        string packetVerification = "NL36";
        public packetReader()
        {

        }
        public void readPacet(Byte[] pac)
        {
            if (readVerification(pac) == true)
            {
                Mesagelength = readHeader(pac);
                Console.WriteLine("Message Length:" + Mesagelength);
                Console.WriteLine("CMD inputed:" + readCMD(pac));
                Console.WriteLine("UserID:" + ReadUserID(pac));
                Console.WriteLine("Message:" + ReadMessage(pac, Mesagelength));
                Console.WriteLine("the full packet:" + Encoding.ASCII.GetString(pac));
            }
            else
            {
                Console.WriteLine("packet not corect verification code");
            }
        }
        public bool readVerification(Byte[] pac)
        {
            Byte[] verByteAray = new Byte[packetVarificationLength];
            String verCode;
            for (int i = 0; i < packetVarificationLength; i++)
            {
                verByteAray[i] = pac[i];
            }
            verCode = Encoding.ASCII.GetString(verByteAray);
            if (verCode == packetVerification)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public int readHeader(Byte[] pac)
        {
            Byte[] headerByteArray = new Byte[headerSize];
            String headerString;
            int messageLegth = 0;
            for (int i = 0; i < headerSize; i++)
            {
                headerByteArray[i] = pac[packetVarificationLength + i];
            }
            headerString = Encoding.ASCII.GetString(headerByteArray);
            headerString.Trim();
            try
            {
                messageLegth = Int32.Parse(headerString);
            }
            catch
            {
                Console.WriteLine("the header is coropted");
            }
            return messageLegth;
        }
        public int readCMD(Byte[] pac)
        {
            byte[] cmdByte = new Byte[cmdByteNum];
            string cmdString;
            int cmd;
            for (int i = 0; i < cmdByteNum; i++)
            {
                cmdByte[i] = pac[packetVarificationLength + headerSize + i];
            }
            cmdString = Encoding.ASCII.GetString(cmdByte);
            try
            {
                cmd = Int32.Parse(cmdString);
            }
            catch
            {
                Console.WriteLine("invaled cmd");
                return 0;
            }
            return cmd;
        }
        public int ReadUserID(Byte[] pac)
        {
            Byte[] userIDBytes = new Byte[userIDLength];
            String userIDString = "";
            int userID = 0;
            for (int i = 0; i < userIDLength; i++)
            {
                userIDBytes[i] = pac[headerSize + packetVarificationLength + cmdByteNum + i];
            }
            userIDString = Encoding.ASCII.GetString(userIDBytes);
            userIDString.Trim();
            try
            {
                userID = Int32.Parse(userIDString);
            }
            catch
            {
                Console.WriteLine("the userID is coropted");
            }
            return userID;
        }
        public string ReadMessage(Byte[] pac, int messageLength)
        {
            Byte[] messageBytes = new Byte[messageLength];
            String Message;
            for (int i = 0; i < messageLength; i++)
            {
                messageBytes[i] = pac[packetVarificationLength + headerSize + cmdByteNum + userIDLength + i];
            }
            Message = Encoding.ASCII.GetString(messageBytes);
            return Message;
        }
    }
}
