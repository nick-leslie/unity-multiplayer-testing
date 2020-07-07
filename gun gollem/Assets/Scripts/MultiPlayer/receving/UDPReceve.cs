using UnityEngine;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System;
using System.Text;
using System.Threading;
public class UDPReceve : MonoBehaviour
{
    [SerializeField]
    private int port;
    IPEndPoint access;
    UdpClient lissener;
    public LinkedList<string> buffer = new LinkedList<string>();
    // Start is called before the first frame update
    void Start()
    {
        access = new IPEndPoint(IPAddress.Any, port);
        lissener = new UdpClient(access);
        Thread ReceveThread = new Thread(StartReceve);
        ReceveThread.Start();
    }
    private void Update()
    {
       // if (buffer.Count > 0)
       // {
       // Debug.Log("value of buffer:" + buffer.Last.Value);
       // buffer.RemoveLast();
       // }
       // Debug.Log("Buffer count:"+buffer.Count);
      
    }
    void StartReceve()
    {
        while (true)
        {
           byte[] gamer  = lissener.Receive(ref access);
            if (gamer.Length >0)
            {
                buffer.AddFirst(Encoding.ASCII.GetString(gamer));
            }
           
        }
    }
}
