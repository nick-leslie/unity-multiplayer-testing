using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class packetCreator
    {
        List<Byte> buffer;
        int headerSize = 10;
        int userIDLength = 2;
        int packetVarificationLength = 4;
        string packetVerification = "NL36";
        public packetCreator()
        {
            buffer = new List<byte>();
        }
        public Byte[] createPacet(int userID, int cmd, string Message)
        {
            writeCMD(cmd);
            writeUserID(userID);
            write(Message);
            Byte[] packet;
            //creaing the header
            int messagelength = buffer.Count - userIDLength;
            string messageHeader = messagelength.ToString().PadRight(headerSize);
            buffer.InsertRange(0, Encoding.ASCII.GetBytes(messageHeader));
            // creatubg the conformation packet
            buffer.InsertRange(0, Encoding.ASCII.GetBytes(packetVerification));
            packet = buffer.ToArray();
            reset();
            return packet;
        }

        void write(Byte[] data)
        {
            buffer.AddRange(data);
        }
        void write(string s)
        {
            buffer.AddRange(Encoding.ASCII.GetBytes(s));
        }
        void writeUserID(int num)
        {
            if (num.ToString().Length <= 2)
            {
                buffer.AddRange(Encoding.ASCII.GetBytes(num.ToString().PadRight(userIDLength)));
            }
            else
            {
                Console.WriteLine("user Id out of scope");
                buffer.AddRange(Encoding.ASCII.GetBytes(0.ToString().PadRight(userIDLength)));
            }
        }
        void writeCMD(int _cmd)
        {
            if (_cmd <= 3)
            {
                buffer.AddRange(Encoding.ASCII.GetBytes(_cmd.ToString()));
            }
            else
            {
                buffer.AddRange(Encoding.ASCII.GetBytes(0.ToString()));
            }
        }
        void reset()
        {
            buffer.Clear();
        }
    }
}
