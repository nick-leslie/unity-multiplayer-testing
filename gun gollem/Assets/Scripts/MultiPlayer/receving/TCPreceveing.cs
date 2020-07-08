using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using UnityEngine;
using System;
public class TCPreceveing : MonoBehaviour
{

    TcpListener lissener;
    [SerializeField]
    private int _port;
    packetReader reader;
    Thread RecvThread;
    // Start is called before the first frame update
    void Start()
    {
        lissener = new TcpListener(IPAddress.Any, _port);
        reader = new packetReader();
        lissener.Start();
        RecvThread = new Thread(ReseveLoop);
        RecvThread.Start();
    }
    void ReseveLoop()
    {
        while (true)
        {
            TcpClient client = lissener.AcceptTcpClient();
            Debug.Log("connected");
            NetworkStream stream = client.GetStream();
            byte[] pac = new byte[256];
            stream.Read(pac, 0, pac.Length);
            Debug.Log(reader.ReadMessage(pac, reader.readHeader(pac)));
        }
    }
}
