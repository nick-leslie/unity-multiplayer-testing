using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    static class packetBuffer
    {
       private static LinkedList<string> _buffer = new LinkedList<string>();

        public static string Getlast()
        {
            if (_buffer.Count>=1)
            {
              return _buffer.Last.Value;
            }
            return null;
        }
        public static void RemoveLast()
        {
            if (_buffer.Count >=1)
            {
                _buffer.RemoveLast();
            }        
        }
        public static string GetFirst()
        {
            if (_buffer.Count >=1)
            {
                return _buffer.First.Value;
            }
            return null;
            
        }
        public static void setFirst(string value)
        {
            _buffer.AddFirst(value);
        }
        public static void clear()
        {
            _buffer = new LinkedList<string>();
        }
    }
}
