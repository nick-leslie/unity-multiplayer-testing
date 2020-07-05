using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
public class UDPsender : MonoBehaviour
{
    [SerializeField]
    private  int port;
    [SerializeField]
    private string ip;
    private IPEndPoint endpoint;
    private UdpClient client;
    public Transform Player;
    private void Start()
    {
        TickManiger.OnTick += delegate (object sender, TickManiger.OnTickEventArgs e)
        {
            Test(e.tick);
        };
    }
    void Test(int tick)
    {
        int port = 11000;
        IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
        UdpClient client = new UdpClient();
        client.Connect(endpoint);
        byte[] sendBytes = Encoding.ASCII.GetBytes(tick.ToString());
        client.Send(sendBytes, sendBytes.Length);
    }
}
