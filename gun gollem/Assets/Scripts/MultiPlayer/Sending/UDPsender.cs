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
    public Movement Player;
    private string lastJason;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>(); ;
        //TickManiger.OnTick += delegate (object sender, TickManiger.OnTickEventArgs e)
        //{
        //  Test(e.tick);
        //};
        TickManiger.tickTimer.Elapsed += delegate (object sender, System.Timers.ElapsedEventArgs e)
        {
            Test(TickManiger.Tick);
        };
    }
    void Test(int tick)
    {
        int port = 11000;
        IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
        UdpClient client = new UdpClient();
        client.Connect(endpoint);
        string jsonData = JsonUtility.ToJson(Player.input);
        if (lastJason!= jsonData)
        {
            byte[] sendBytes = Encoding.ASCII.GetBytes(jsonData);
            client.Send(sendBytes, sendBytes.Length);
            lastJason = jsonData;
        }
        
    }
}
