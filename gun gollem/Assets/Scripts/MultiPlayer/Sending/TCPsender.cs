﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
public class TCPsender : MonoBehaviour
{
    [SerializeField]
    private string _ip;
    [SerializeField]
    private int _port;
    TcpClient sender;
    NetworkStream stream;
    packetCreator creator;
    // Start is called before the first frame update
    void Start()
    {
        creator = new packetCreator();
    }
    public void conformWithServer()
    {
        byte[] pac=creator.createPacet(0, 0,"this is a test");
        send(pac);
    }
    void send(byte[] pac)
    {
        connetToServer();
        stream.Write(pac, 0, pac.Length);
        stream.Flush();
    }
    public void connetToServer()
    {
        sender = new TcpClient(_ip, _port);
        stream = sender.GetStream();
    }
}