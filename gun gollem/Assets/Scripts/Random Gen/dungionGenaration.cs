using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dungionGenaration : MonoBehaviour
{
    public int runs;
    public int rounds;
    public GameObject room;
    public List<Vector2Int> visted = new List<Vector2Int>();
    public int distTillStare;
    public float chance;
    private bool hadStair = false;
    private Grid grid;
    [SerializeField]
    private int Width;
    [SerializeField]
    private int Height;
    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(Width, Height, 10f);
        genarate();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))

        {
            genarate();
        }
    }
    void genarate()
    {
        for (int g = 0; g < rounds; g++)
        {
            Vector2Int pos = new Vector2Int(Width/2, Height/2);
            grid.setNum(pos, 1);
            Instantiate(room, grid.getCenterOfCell(pos), room.transform.rotation);
            if (g == 0)
            {
                visted.Add(pos);
            }
            CreateText.createWorldText(null, "spawn", grid.getCenterOfCell(pos), 20, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center, 2);

            for (int i = 0; i < runs; i++)
            {

                bool seen = false;
                //assining Direction
                // Vector2Int direction = RandomDire();
                // pos += direction;
                Vector2Int nextPos = newPosition(pos);
                if(Vector2Int.Distance(nextPos,pos)==0)
                {
                    break;
                }
                pos = nextPos;
                for (int j = 0; j < visted.Count; j++)
                {
                    if (Vector2Int.Distance(pos, visted[j]) == 0)
                    {
                        seen = true;
                    }
                }
                if (seen == false)
                {
                    visted.Add(pos);
                    grid.setNum(pos, grid.GetNum(pos) + 1);
                    Debug.Log("added move:" + pos);
                }
               
            }
        }
        Vector2Int furthestPos = visted[0];
        for (int i = 0; i < visted.Count; i++)
        {
            float workingDist = Vector2Int.Distance(visted[0], visted[i]);
            if (workingDist >= Vector2Int.Distance(visted[0], furthestPos))
            {
                furthestPos = visted[i];
            }
        }
        for (int i = 0; i < visted.Count; i++)
        {
            SetRooms(visted[i]);
        }
        CreateText.createWorldText(null, "stairs", grid.getCenterOfCell(furthestPos), 20, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center, 2);
    }
  void SetRooms(Vector2Int pos)
    {
        GameObject SpawnedRoom = Instantiate(room, grid.getCenterOfCell(pos), transform.rotation);
        RoomManagement maniger = SpawnedRoom.GetComponent<RoomManagement>();
        if (grid.CheckUPForNabor(pos) == false)
        {
            maniger.top.SetActive(true);
        }
        if (grid.CheckDownForNabor(pos) == false)
        {
            maniger.Bottom.SetActive(true);
        }
        if (grid.CheckRightForNabor(pos) == false)
        {
            maniger.Right.SetActive(true);
        }
        if (grid.CheckLeftForNabor(pos) == false)
        {
            maniger.Left.SetActive(true);
        }
    }
    Vector2Int newPosition(Vector2Int pos)
    {
        List<Vector2Int> nabor = new List<Vector2Int>();
        if (grid.getValidNaborPos(pos, ref nabor))
        {
            Vector2Int[] ValledPositions = nabor.ToArray();

            if (ValledPositions.Length > 0)
            {
                int choice = Random.Range(0, ValledPositions.Length - 1);
                Debug.Log("choise:"+choice);
                // trim nabor List to just the choice

                return ValledPositions[choice];
            }
        }
        return pos;
    }
    bool edgeCheckX(Vector2Int pos)
    {
        if (pos.x >= grid.Width || pos.x<=0)
        {
            return true;
        }
        return false;
    }
    bool edgeCheckY(Vector2Int pos)
    {

        if (pos.y >= grid.Height || pos.y <= 0)
        {
            return true;
        }
        return false;
    }
    bool cornerCheck(Vector2Int pos)
    {
        if (edgeCheckX(pos) && edgeCheckY(pos))
        {
            return true;
        }
        return false;
    }
    Vector2Int RandomDire()
    {
        int x=0;
        int y=0;
        int coinFlip;
        //see wich random is chosen first
        coinFlip = Random.Range(0, 2);
        if (coinFlip < 1)
        {
            //X has priority  
            x = Random.Range(-1, 2);
            while (x == 0 && y == 0)
            {
                x = Random.Range(-1, 2);
            }
        }
        else
        {
            y = Random.Range(-1, 2);

            while (x == 0 && y == 0)
            {
                y = Random.Range(-1, 2);
            }
        }
        return new Vector2Int(x, y);
    }
}
